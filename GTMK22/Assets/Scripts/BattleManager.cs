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

    }

    void TakePlayerTurn()
    {
        action = player.dice[dieNumber].RollDie();
        isEnemyDead = enemy.DealDamage(action[0]);
        switch (action[1])
        {
            case 0:
                Debug.Log("Poison placeholder!");
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

    }

    void TakeEnemyTurn()
    {
        action = enemy.TakeTurn();
        player.ChangeHealth(-action[0]);
        switch (action[1])
        {
            case 0:
                Debug.Log("Poison from enemy placeholder");
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
    }
}
