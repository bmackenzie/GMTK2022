using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMulti : Enemy
{
    public bool attacking = false;
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
        if (attacking)
        {
            Debug.Log("MultiAttack");
            return new int[] { 0, 7, 3 };
        }
        else
        {
            Debug.Log("Buffing Strength");
            return new int[] { 0, 6, 1 };
        }

    }
}
