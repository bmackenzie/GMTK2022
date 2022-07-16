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
        if (scaleCount%scaleFactor == 0)
        {
            return new int[] { 0, 6 , 1};
        }
        else
        {
            return new int[] { damage, 0, 0 };
        }
        
    }
}
