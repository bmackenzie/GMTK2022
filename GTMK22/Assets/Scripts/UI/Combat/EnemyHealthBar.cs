using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Enemy enemy;

    
    private void Awake()
    {
        enemy = FindObjectOfType<Enemy>();
    }


    public void Update() 
    {
        //Debug.Log("updating enemy healthbar: "+ Mathf.Clamp((float)enemy.health / enemy.maxHealth, 0.0f, 1.0f).ToString());
        try
        {
            healthBarImage.fillAmount = Mathf.Clamp((float)enemy.health / enemy.maxHealth, 0.0f, 1.0f);
        }
        catch
        {
            enemy = FindObjectOfType<Enemy>();
        }
    }
}