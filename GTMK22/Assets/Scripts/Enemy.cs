using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage { get; private set; }
    public int health { get; private set; }
    //TODO: Maybe add special abilities

    // Start is called before the first frame update
    void Start()
    {
        // Initialize values for damage and health
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int TakeAction()
    {
        // TODO: Do action
        return -1;
    }
}
