using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoison : Enemy
{
    private int poisonStrength = 2;
    
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
            return new int[] { 0, 1, poisonStrength };
        }

    }
}
