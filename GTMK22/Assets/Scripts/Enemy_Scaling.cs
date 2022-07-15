using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Scaling : Enemy
{
    private int scale_factor = 5;
    private int scale_count = 0;
    public int TakeTurn()
    {
        // TODO: Do your turn
        scale_count++;
        if (scale_count%scale_factor == 0)
        {
            damage++;
            return 0;
        }
        else
        {
            return damage;
        }
        
    }
}
