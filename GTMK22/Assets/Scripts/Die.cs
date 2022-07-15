using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int numSides { get; private set; }
    public int[] sideAction { get; private set; }

    
    
    // Start is called before the first frame update
    void Start()
    {
        SetNumSides(6);
        sideAction = new int[numSides];
        
    }

    // Update is called once per frame
    void Update()
    {
        return;
    }

    public void SetNumSides(int sides)
    {
        numSides = sides;   
        return;
    }

    public void ChangeSide(int side, int action)
    {
        // TODO: Update side and action
        sideAction[side] = action;
        return;
    }

    public int[] RollDie()
    {
        // TODO: Get a side action and return it?
        int currentFace = Random.Range(0, numSides-1);
        int currentAction = sideAction[currentFace];
        return new int[] {currentFace, currentAction};
    }

    void Merge(Die secondDie, Die thirdDie)
    {
        // TODO: Maybe merging?
        return;
    }
}
