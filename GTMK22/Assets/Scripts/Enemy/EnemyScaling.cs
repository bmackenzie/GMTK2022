using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaling : Enemy
{
    private int scaleFactor = 2;
    private int scaleCount = 0;

    public override void Start()
    {
        // Initialize values for damage and health
        // for initial testing purposes
        maxHealth = 30;
        ChangeHealth(maxHealth);
        damage = 1;
    }

    public override int[] TakeTurn()
    {
        // TODO: Do your turn
        scaleCount++;
        if (scaleCount%scaleFactor == 0)
        {
            return new int[] { damage, 6 , 1};
        }
        else
        {
            return new int[] { damage, 0, 0 };
        }
        
    }
}
