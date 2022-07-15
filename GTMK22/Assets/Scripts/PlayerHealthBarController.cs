using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
  public Image healthBarImage;
  public Player player; // needs to reference player stuff


  public void UpdateHealthBar() 
  {
	healthBarImage.fillAmount = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
  }

}