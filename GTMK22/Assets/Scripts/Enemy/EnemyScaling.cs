using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaling : Enemy
{
    private int scaleFactor = 5;
    private int scaleCount = 0;
    public override int[] TakeTurn()
    {
        // TODO: Do your turn
        scaleCount++;
        Debug.Log(damage);
        if (scaleCount%scaleFactor == 0)
        {
            damage++;
            return new int[] { 0, 0 , 0};
        }
        else
        {
            return new int[] { damage, 0, 0 };
        }
        
    }
}
