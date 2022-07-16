using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThorns : Enemy
{
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
            Debug.Log("should be increasing the thorn strength");
            return new int[] { 0, 3, 1};
        }

    }
}
