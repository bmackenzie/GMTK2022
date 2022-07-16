using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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
    public GameObject lifeIcon;
    public GameObject diceIcon;
    private int[] speeds = {1,2,4};
    private int speedIndex = -1;
    

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
        UpdateRoundNumber();
        UpdateSpeedNumber();
        
    }

    
    public void DrawLives()
    {   
        //Debug.Log("started controller");
        for(int lvs=1;lvs <= player.lives; lvs++)
        {
            //Debug.Log("Lives: " + lvs.ToString());
            GameObject lifeIcon = Instantiate(lifesPrefab);
            lifeIcon.transform.position += new Vector3((lvs-1)*1, 0, 0);
        }
    }
        
    public void DrawDie()
    {
        for(int die=1;die <= player.dice.Count; die++)
        {
            //Debug.Log("Dice: " + die.ToString());
            GameObject diceIcon = Instantiate(dicePrefab);
            diceIcon.transform.position += new Vector3((float)((die-1)*1.25), 0.0f, 0.0f);
        }
    }

    public void UpdateRoundNumber()
    {
        roundText.text = "Round " + gameManager.rounds.ToString();
        return;
    }

    public void UpdateSpeedNumber()
    {
        speedIndex ++;
        speedText.text = speeds[speedIndex].ToString() + "X";
        battleManager.updateSpeed = speeds[speedIndex];
        return;
    }

}
