using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeavy : Enemy
{
    // Start is called before the first frame update
    public override void Start()
    {
        // Initialize values for damage and health
        // for initial testing purposes
        maxHealth = 40;
        ChangeHealth(maxHealth);
        damage = 4;
    }

}
