using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : Enemy
{
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
        int act = Random.Range(0, 2);
        if (act == 0)
        {
            Debug.Log("Dodging");
            return new int[] { 0, 4, 1 };
        }
        else
        {
            Debug.Log("Beeg hit");
            return new int[] { 0, 5, 15 };
        }

    }
}
