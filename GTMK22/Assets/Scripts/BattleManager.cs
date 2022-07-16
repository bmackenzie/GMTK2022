using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
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
        if(isPlayerDead || isEnemyDead)
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
    }

    void TakePlayerTurn()
    {
        action = player.dice[dieNumber].RollDie();
        isEnemyDead = enemy.ChangeHealth(-action[0]);
        switch (action[1])
        {
            case 0:
                enemy.ChangePoison(action[2]);
                Debug.Log("Poison placeholder!");
                enemy.ChangeHealth(-enemy.poisonCounter);
                // code block
                break;
            case 1:
                Debug.Log("armor placeholder");
                // code block
                break;
            default:
                // code block
                Debug.Log("No fancy status placeholder");
                break;
        }
        if (enemy.poisonCounter > 0)
        {
            enemy.ChangePoison(-1);
        }
    }

    void TakeEnemyTurn()
    {
        action = enemy.TakeTurn();
        player.ChangeHealth(-action[0]);
        switch (action[1])
        {
            case 0:
                player.ChangePoison(action[2]);
                Debug.Log("Poison from enemy placeholder");
                player.ChangeHealth(-player.poisonCounter);
                // code block
                break;
            case 1:
                Debug.Log("armor from enemy placeholder");
                // code block
                break;
            default:
                // code block
                Debug.Log("No fancy status from enemy placeholder");
                break;
        }
        if (player.poisonCounter > 0)
        {
            player.ChangePoison(-1);
        }
    }
}
