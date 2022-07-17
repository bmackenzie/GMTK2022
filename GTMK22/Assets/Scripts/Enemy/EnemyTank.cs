using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : Enemy
{
    public override void Start()
    {
        // Initialize values for damage and health
        // for initial testing purposes
        maxHealth = 60;
        ChangeHealth(maxHealth);
        damage = 1;
    }
    public override int[] TakeTurn()
    {
        // TODO: Do your turn
        int act = Random.Range(0, 2);
        if (act == 0)
        {
            Debug.Log("Adding Damage reduction");
            return new int[] { 0, 3, 1 };
        }
        else
        {
            Debug.Log("Increasing the thorn strength");
            return new int[] { 0, 2, 1};
        }

    }
}
