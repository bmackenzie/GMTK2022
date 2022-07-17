using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class CombatUIController : MonoBehaviour
{
    public Image playerLivesIcon;
    private Player player;
    private Enemy enemy;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI speedText;
    public GameManager gameManager;
    public BattleManager battleManager;
    public GameObject lifesPrefab;
    public GameObject dicePrefab;
    public GameObject enemySummonsPrefab;
    public GameObject lifeIcon;
    public GameObject diceIcon;
    public GameObject enemyIcon;
    private int[] speeds = {1,2,4};
    private int speedIndex = -1;
    private bool attackAnimationComplete = true;
    

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
        gameManager = FindObjectOfType<GameManager>();
        battleManager = FindObjectOfType<BattleManager>();
    }

    public void Start() 
    {
        DrawLives();
        DrawDie();
        DrawEnemySummons();
        UpdateRoundNumber();
        UpdateSpeedNumber();
        
    }

    
    public void DrawLives()
    {   
        //Debug.Log("started controller");
        for(int lvs=1;lvs <= player.maxLives; lvs++)
        {
            //.Log("Lives: " + lvs.ToString());
            GameObject lifeIcon = Instantiate(lifesPrefab, this.transform);
            lifeIcon.transform.position += new Vector3((lvs-1)*1, 0, 0);
            if(lvs > player.lives)
            {
                lifeIcon.GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }

        
    public void DrawDie()
    {
        for (int i = 0; i < player.dice.Count; i++)
        {
            player.dice[i].transform.position = new Vector3((float)(((i-1)*2)-5), -5.0f, 0.0f);
            
            // Debug.Log("Dice: " + die.ToString());
            // GameObject diceIcon = Instantiate(dicePrefab);
            //diceIcon.transform.position += new Vector3((float)((die-1)*1.25), 0.0f, 0.0f);
        }
    }

    public void DrawEnemySummons()
    {
        //for (int i = 0; i < enemy.summons; i++)
        //{
            
        //    //Debug.Log("Enemy: " + i.ToString());
        //    GameObject enemyIcon = Instantiate(enemySummonsPrefab);
        //    enemyIcon.transform.position = new Vector3((float)(-((i-1)*(enemy.summons-1))+5), 0.0f, 0.0f);
        //}
    }


    public void UpdateRoundNumber()
    {
        roundText.text = "Round " + gameManager.rounds.ToString();
        return;
    }

    public void UpdateSpeedNumber()
    {
        speedIndex ++;
        speedIndex = speedIndex % 3;
        speedText.text = speeds[speedIndex].ToString() + "X";
        battleManager.updateSpeed = speeds[speedIndex]*4;
        return;
    }

    public void DrawAttackSymbol()
    {
        //Debug.Log("started controller");
        if (attackAnimationComplete)
        {

        }

    }
}
