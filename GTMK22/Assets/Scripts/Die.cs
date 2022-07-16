using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Die : MonoBehaviour
{
    public int numSides = 4;
    public int[][] sideAction { get; private set; }
    public BonusGoop[] sideBonuses { get; private set; }
   

    // Start is called before the first frame update
    public void Awake()
    {
        SetNumSides(numSides);
    }

    public void SetNumSides(int sides)
    {
        numSides = sides;
        sideBonuses = new BonusGoop[numSides];
        sideAction = new int[numSides][]; //fill sideAction w/ zeros
        for (int i = 0; i < numSides; i++)
        {
            sideAction[i] = new int[2];
            sideBonuses[i] = new BonusGoop((BonusTypes)0, 0, "nothing fancy");
        }
        // Randomly set a single side with a random bonus
        sideBonuses[Random.Range(0, numSides - 1)] = new BonusGoop((BonusTypes)0, 0, "nothing fancy");//DieLibrary.GetRandomGoop();

    }

    public void ChangeSide(int side, BonusGoop action)
    {
        if (side > 0 && side <= numSides )
        {
            sideBonuses[side] = action;
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
        BonusGoop currentAction = sideBonuses[currentFace];
        return new int[] {currentFace, (int)currentAction.bonusType, currentAction.magnitude};
    }

    void Merge(Die secondDie, Die thirdDie)
    {
        // TODO: Maybe merging?
        return;
    }
}
