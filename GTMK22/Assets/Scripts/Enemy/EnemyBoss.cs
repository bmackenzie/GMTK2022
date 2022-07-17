using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    int[] DAMAGE;
    public override void Start()
    {
        // Initialize values for damage and health
        // for initial testing purposes
        maxHealth = 100;
        ChangeHealth(maxHealth);
        damage = 2;
    }
    public override int[] TakeTurn()
    {
        // TODO: Do your turn
        int act = Random.Range(0, 8);
        
        switch (act)
        {
            case 0:
                DAMAGE = new int[]{ damage, act, 0 };
                break;
            case 1: //poison attack
                DAMAGE = new int[]{ damage, act, 3 };
                break;
            case 2: //thorn buff
                DAMAGE = new int[] { damage, act, 1 };
                break;
            case 3: //Damage Reduction Buff
                DAMAGE = new int[] { damage, act, 2 };
                break;
            case 4: //Dodge Buff
                DAMAGE = new int[] { damage, act, 1 };
                break;
            case 5: //self stun attack
                DAMAGE = new int[] { damage, act, 7 };
                break;
            case 6: //increase damage
                DAMAGE = new int[] { damage, act, 1 };
                break;
            case 7: //additional attacks
                DAMAGE = new int[] { damage, act, 1 };
                break;
            default:
                Debug.Log("we should not be here");
                DAMAGE = new int[] { damage, 0, 0 };
                break;
        }
        return DAMAGE;
    }
}
