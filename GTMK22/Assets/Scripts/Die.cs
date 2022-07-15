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
        SetNumSides(6); // initialize die side number
        sideAction = new int[numSides]; //fill sideAction w/ zeros
        
    }

    public void SetNumSides(int sides)
    {
        numSides = sides;   
        return;
    }

    public void ChangeSide(int side, int action)
    {
        if (side > 0 && side <= numSides )
        {
            sideAction[side] = action;
        }
        else
        {
            Debug.Log("Side does not exist on die");
        }
        return;
    }

    public int[] RollDie()
    {
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
