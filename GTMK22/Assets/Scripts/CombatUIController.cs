using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUIController : MonoBehaviour
{
    public Image playerHealthBarImage;
    public Image enemyHealthBarImage;
    public Image playerLivesIcon;
    public Player player;
    public Enemy enemy;
    public GameObject lifesPrefab;
    public GameObject dicePrefab;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
        //gameObject = FindObjectOfType<GameObject>();
    }

    public void Start() 
    {   
        Debug.Log("started controller");
        for(int lvs=1;lvs <= player.lives; lvs++)
        {
            Debug.Log("Lives: " + lvs.ToString());
            GameObject lifeIcon = Instantiate(lifesPrefab);
            lifeIcon.transform.position += new Vector3((lvs-1)*1, 0, 0);
        }
        
        for(int die=1;die <= player.dice.Count; die++)
        {
            Debug.Log("Dice: " + die.ToString());
            GameObject diceIcon = Instantiate(dicePrefab);
            diceIcon.transform.position += new Vector3((float)((die-1)*1.25), 0.0f, 0.0f);
        }
    }

    public void UpdateHealthBar()
    {
        // playerHealthBarImage.fillAmount = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
        // enemyHealthBarImage.fillAmount = Mathf.Clamp(enemy.health / enemy.maxHealth, 0, 1f);
    }

    public void UpdateRoundNumber()
    {
        return;
    }

}
