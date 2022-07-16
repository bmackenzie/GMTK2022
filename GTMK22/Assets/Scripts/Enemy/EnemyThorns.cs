using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThorns : Enemy
{
    private int thornStrength = 1;

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
            thornStrength++;
            return new int[] { 0, 0, 0};
        }

    }
}
