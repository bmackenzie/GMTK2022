using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUIController : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
