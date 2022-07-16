using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeavy : Enemy
{
    // Start is called before the first frame update
    public override void Start()
    {
        damage = 4;
        health = 100;
    }

}
