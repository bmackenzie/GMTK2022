using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
    private int updateFlag = 0;
    public int updateSpeed = 100;

    private int enemyPoison = 0;
    private int enemyThorn = 0;
    private int enemyDodgeTurn = 0;
    private int enemyDamageReduce = 0;
    private bool enemySkipTurn = false;
    private int enemyStrength = 0;

    private int playerPoison = 0;
    private int playerThorn = 0;
    private int playerDodgeTurn = 0;
    private int playerDamageReduce = 0;
    private bool playerSkipTurn = false;
    private int playerStrength = 0;
    private int attackStrength = 0;
    private bool wasAttacked = false;
    private GameManager gameManager;
    private GameObject test1;




    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        switch (gameManager.rounds)
        {
            case 1:
                test1 = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyBase.prefab", typeof(GameObject)),this.transform);
                Debug.Log("loaded Enemy Base prefab");
                break;
            case 2:
                test1 = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyDodge.prefab", typeof(GameObject)), this.transform);
                Debug.Log("loaded Enemy Dodge prefab");

                break;
            case 3:
                test1 = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyThorns.prefab", typeof(GameObject)), this.transform);
                Debug.Log("loaded Enemy Thorns prefab");

                break;
            case 4:
                test1 = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyHeavy.prefab", typeof(GameObject)), this.transform);
                Debug.Log("loaded Enemy Heavy prefab");

                break;
            case 5:
                test1 = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyScaling.prefab", typeof(GameObject)), this.transform);
                Debug.Log("loaded Enemy Scaling prefab");

                break;
            case 6:
                test1 = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyPoison.prefab", typeof(GameObject)), this.transform);
                Debug.Log("loaded Enemy Poison prefab");

                break;
            case 7:
                test1 = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Enemy6.prefab", typeof(GameObject)), this.transform);
                Debug.Log("loaded Enemy 6 prefab");

                break;
            case 8:
                test1 = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyTank.prefab", typeof(GameObject)), this.transform);
                Debug.Log("loaded Enemy Tank prefab");

                break;
            case 9:
                test1 = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyMulti.prefab", typeof(GameObject)), this.transform);
                Debug.Log("loaded Enemy Multi prefab");

                break;
            case 10:
                test1 = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyBoss.prefab", typeof(GameObject)), this.transform);
                Debug.Log("loaded Enemy Boss prefab");

                break;
            default:
                Debug.Log("sould not be here");
                break;

        }
        test1.transform.position += new Vector3(4, -5, 0);
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
        if(this.isPaused)
        {
            return;
        }
        
        if(updateFlag < (1000 / updateSpeed))
        {
            updateFlag++;
            return;
        }
        updateFlag = 0;
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
        
        //Debug.Log(player.health);
    }

    void TakePlayerTurn()
    {
        if (!playerSkipTurn)
        {
            action = player.dice[dieNumber].RollDie();
            dieNumber++;
            dieNumber = dieNumber % 3;
            if (action[0] > 0)
            {
                attackStrength = Mathf.Min(-action[0] - playerStrength + enemyDamageReduce, 0);
                HurtEnemy(attackStrength);
                wasAttacked = true;
            }
            
            switch (action[1])
            {
                case 0:
                    break;
                case 1: //poison attack
                    enemyPoison += action[2];
                    break;
                case 2: //thorn buff
                    playerThorn += action[2];
                    break;
                case 3: //Damage Reduction Buff
                    playerDamageReduce += action[2];
                    break;
                case 4: //Dodge Buff
                    playerDodgeTurn += action[2];
                    break;
                case 5: //self stun attack
                    playerSkipTurn = true;
                    isEnemyDead = enemy.ChangeHealth(-action[2]);
                    break;
                case 6: //increase damage
                    playerStrength += action[2];
                    break;
                case 7: //additional attacks
                    for (int i = 0; i < action[2]; i++)
                    {
                        HurtEnemy(attackStrength);
                    }
                    wasAttacked = true;
                    break;
            }
        }
        else
        {
            playerSkipTurn = false;
        }

        if (playerPoison > 0)
        {
            isPlayerDead = player.ChangeHealth(-playerPoison);
            playerPoison -= 1;
        }
        if (wasAttacked)
        {
            enemyDamageReduce = 0;
            wasAttacked = false;
        }
        
    }

    void TakeEnemyTurn()
    {
        Debug.Log("Taking enemy turn");
        if (!enemySkipTurn)
        {
            action = enemy.TakeTurn();
            if (action[0] > 0)
            {
                attackStrength = Mathf.Min(-action[0] - enemyStrength + playerDamageReduce, 0);
                HurtPlayer(attackStrength);
                wasAttacked = true;
            }
            else
            {
                attackStrength = 0;
            }
            
            switch (action[1])
            {
                case 0:
                    break;
                case 1:
                    playerPoison += action[2];
                    break;
                case 2: //thorn buff
                    enemyThorn += action[2];

                    break;
                case 3: //Damage Reduction Buff
                    enemyDamageReduce += action[2];
                    break;
                case 4: //Dodge Buff
                    enemyDodgeTurn += action[2];
                    break;
                case 5: //self stun attack
                    enemySkipTurn = true;
                    isPlayerDead = player.ChangeHealth(-action[2]);
                    break;
                case 6: //damage boost
                    enemyStrength += action[2];
                    break;
                case 7: //additional attacks
                    for (int i = 0; i < action[2]; i++)
                    {
                        HurtPlayer(attackStrength);
                    }
                    wasAttacked = true;
                    break;
            }

        }
        else
        {
            enemySkipTurn = false;
        }
        if (enemyPoison > 0)
        {
            isEnemyDead = enemy.ChangeHealth(-enemyPoison);
            enemyPoison -= 1;
        }
        if (wasAttacked)
        {
            playerDamageReduce = 0;
            wasAttacked = false;
        }

    }

    void HurtPlayer(int damage)
    {
        //stuff
        if (playerDodgeTurn > 0)
        {
            playerDodgeTurn -= 1;
        }
        else
        {
            isPlayerDead = player.ChangeHealth(damage);
            if (playerThorn > 0)
            {
                isEnemyDead = enemy.ChangeHealth(-playerThorn);
            }
        }

    }

    void HurtEnemy(int damage)
    {
        //things
        if (enemyDodgeTurn > 0)
        {
            enemyDodgeTurn -= 1;
        }
        else
        {
            isEnemyDead = enemy.ChangeHealth(damage);
            if (enemyThorn > 0)
            {
                isPlayerDead = player.ChangeHealth(-enemyThorn);
            }
        }
    }

    void EndFight()
    {
        //clean up fight, move to next scene
        FindObjectOfType<SceneLoader>().LoadSpecificScene("shop");
    }
}
