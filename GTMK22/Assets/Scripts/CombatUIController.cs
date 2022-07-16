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
    public GameObject gameobject;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
        //gameObject = FindObjectOfType<GameObject>();
    }

    public void CreateObject(string prefabName) 
    {
        for(int lvs=1;lvs <= player.lives; lvs++)
        {
            GameObject lifeIcon = GameObject.Instantiate(Resources.Load("LivesIcon")) as GameObject;
            lifeIcon.transform.position += new Vector3(10*lvs, 0, 0);
        }
    
    }

    public void UpdateHealthBar()
    {
        playerHealthBarImage.fillAmount = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
        enemyHealthBarImage.fillAmount = Mathf.Clamp(enemy.health / enemy.maxHealth, 0, 1f);
    }

    public void UpdateRoundNumber()
    {
        return;
    }

    public void UpdateLivesIcons()
    {
        CreateObject("LiveIcon");
    }

}
