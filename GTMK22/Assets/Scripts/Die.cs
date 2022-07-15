using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int numSides = 6;
    public int[] sideAction { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        // TODO: Generate side actions?
        // TODO: Health?
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSide(int side, int action)
    {
        // TODO: Update side and action
        return;
    }

    public int RollDie()
    {
        // TODO: Get a side action and return it?
        return -1;
    }

    void Merge(Die secondDie, Die thirdDie)
    {
        // TODO: Maybe merging?
        return;
    }
}
