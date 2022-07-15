using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage { get; protected set; }
    public int health { get; protected set; }

    //TODO: Maybe add special abilities

    // Start is called before the first frame update
    void Start()
    {
        // Initialize values for damage and health
        // for initial testing purposes
        health = 20;
        damage = 1;
        Debug.Log("I am alive!");
    }

    // Update is called once per frame
    void Update()
    {
        // used for animations and the like
    }

    public int[] TakeTurn()
    {
        // TODO: Do your turn

        return new int[] {damage, 0};
    }

    public bool DealDamage(int incomingDamage)
    {
        health -= incomingDamage;
        if (health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
