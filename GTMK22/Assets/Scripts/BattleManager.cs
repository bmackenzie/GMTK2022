using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : DialoguePauser
{
    // Start is called before the first frame update
    private bool playerTurn = true;
    private int dieNumber = 0;
    public Player player;
    public Enemy enemy;
    private int[] action;
    private bool isEnemyDead = false;
    private bool isPlayerDead = false;


    private void Awake()
    {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
    }

    void Start()
    {
        
    }

    bool StartBattle(Player thePlayer, Enemy newFoe)
    {
        enemy = newFoe;
        player = thePlayer;
        while (!(isPlayerDead || isEnemyDead))
        {
            if (playerTurn)
            {
                TakePlayerTurn();
                playerTurn = false;
            }
            else
            {
                TakeEnemyTurn();
                playerTurn = true;
            }
        }
        return isEnemyDead;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerDead || isEnemyDead)
        {
            FindObjectOfType<GameManager>().EndBattle(isEnemyDead);
        }

        if (playerTurn)
        {
            TakePlayerTurn();
            playerTurn = false;
        }
        else
        {
            TakeEnemyTurn();
            playerTurn = true;
        }
        
        Debug.Log(player.health);
    }

    void TakePlayerTurn()
    {
        action = player.dice[dieNumber].RollDie();
        isEnemyDead = enemy.ChangeHealth(-action[0]);
        switch (action[1])
        {
            case 0:
                break;
            case 1:
                enemy.ChangePoison(action[2]);
                Debug.Log("Poison placeholder!");
                isEnemyDead = enemy.ChangeHealth(-enemy.poisonCounter);
                break;
        }
        if (enemy.poisonCounter > 0)
        {
            enemy.ChangePoison(-1);
        }
        if ((enemy.thornStrength > 0)&&(action[0] > 0))
        {
            isPlayerDead = player.ChangeHealth(-enemy.thornStrength);
        }
    }

    void TakeEnemyTurn()
    {
        action = enemy.TakeTurn();
        player.ChangeHealth(-action[0]);
        switch (action[1])
        {
            case 0:
                break;
            case 1:
                player.ChangePoison(action[2]);
                Debug.Log("Our current poison level");
                Debug.Log(player.poisonCounter);
                isPlayerDead = player.ChangeHealth(-player.poisonCounter);
                break;
        }
        if (player.poisonCounter > 0)
        {
            player.ChangePoison(-1);
        }
        if ((player.thornStrength > 0) && (action[0] > 0))
        {
            isEnemyDead = enemy.ChangeHealth(-player.thornStrength);
        }
    }
}
