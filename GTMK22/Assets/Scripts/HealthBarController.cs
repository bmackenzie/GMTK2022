using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
  public Image playerHealthBarImage;
  public Image enemyHealthBarImage;

  public Player player;
  public Enemy enemy;

  public void UpdateHealthBar() 
  {
	playerHealthBarImage.fillAmount = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
	enemyHealthBarImage.fillAmount = Mathf.Clamp(enemy.health / enemy.maxHealth, 0, 1f);

  }

}