using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThorns : Enemy
{
    public override void Start()
    {
        // Initialize values for damage and health
        // for initial testing purposes
        maxHealth = 40;
        ChangeHealth(maxHealth);
        damage = 1;
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
            Debug.Log("should be increasing the thorn strength");
            return new int[] { 0, 3, 2};
        }

    }
}
