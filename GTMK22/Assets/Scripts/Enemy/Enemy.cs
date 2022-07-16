using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage { get; protected set; }
    public int health { get; protected set; } = 0;
    public int maxHealth { get; private set; }
    public int summons = 3;

    //TODO: Maybe add special abilities

    // Start is called before the first frame update
    public virtual void Start()
    {
        // Initialize values for damage and health
        // for initial testing purposes
        maxHealth = 20;
        ChangeHealth(maxHealth);
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // used for animations and the like
    }

    public virtual int[] TakeTurn()
    {
        // TODO: Do your turn
        return new int[] {damage, 0, 0};
    }
    public bool DealDamage(int something)
    {
        return false;
    }
    public bool ChangeHealth(int healthChange)
    {
        health += healthChange;
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
