using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Player player;


    public void Update() 
    {
        //Debug.Log("updating healthbar"+ player.health.ToString());
        healthBarImage.fillAmount = Mathf.Clamp((float)player.health / player.maxHealth, 0, 1f);
    }
}
