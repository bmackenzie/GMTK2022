using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodge : Enemy
{
    public override void Start()
    {
        // Initialize values for damage and health
        // for initial testing purposes
        maxHealth = 20;
        ChangeHealth(maxHealth);
        damage = 5;
    }
    public override int[] TakeTurn()
    {
        // TODO: Do your turn
        int act = Random.Range(0, 2);
        if (act == 0)
        {
            return new int[] { damage, 0, 0 };
        }
        else
        {
            Debug.Log("should be adding a dodge");
            return new int[] { 0, 4, 1 };
        }

    }
}
