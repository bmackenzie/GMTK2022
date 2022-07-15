using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health { get; private set; }
    public int lives { get; private set; }
    public int money { get; private set; }
    public Die[] dice { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(int changeValue)
    {
        health += changeValue;
        if( health <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        //TODO: DIE DIE DIE DIE
        return;
    }
}
