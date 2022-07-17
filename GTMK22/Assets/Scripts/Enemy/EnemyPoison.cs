using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoison : Enemy
{
    private int poisonStrength = 2;

    public override void Start()
    {
        // Initialize values for damage and health
        // for initial testing purposes
        maxHealth = 50;
        ChangeHealth(maxHealth);
        damage = 1;
    }

    public override int[] TakeTurn()
    {
        // TODO: Do your turn
        return new int[] { damage, 1, poisonStrength };

    }
}
