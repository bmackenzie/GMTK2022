using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Die : MonoBehaviour
{
    public int numSides = 4;
    public int[][] sideAction { get; private set; }
    public BonusGoop[] sideBonuses { get; private set; }
    private DieDatabase dieDatabase = new DieDatabase();
    public SpriteRenderer slimeSprite;
    

    // Start is called before the first frame update
    public void Awake()
    {
        SetNumSides(numSides);
        this.slimeSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void SetNumSides(int sides)
    {
        numSides = sides;
        sideBonuses = new BonusGoop[numSides];
        sideAction = new int[numSides][]; //fill sideAction w/ zeros
        for (int i = 0; i < numSides; i++)
        {
            sideAction[i] = new int[2];
            sideBonuses[i] = new BonusGoop((BonusTypes)0, 0, 0, "nothing fancy");
        }
        // Randomly set a single side with a random bonus
        int temp = Random.Range(0, numSides - 1);
        sideBonuses[temp] = dieDatabase.GetRandomGoop();
        sideBonuses[temp].SetMagnitude(temp);
        //for (int i = 0; i < numSides; i++)
        //{
        //    Debug.Log("Player dice sides");
        //    Debug.Log(sideBonuses[i].bonusType);
        //    Debug.Log(sideBonuses[i].magnitude);
        //    Debug.Log(sideBonuses[i].description);
        //}
    }

    public string GetFaceInfo()
    {
        int magnitude;
        BonusTypes bonusType;
        string returnString = "";
        for (int i =0; i < numSides; i++)
        {
            magnitude = sideBonuses[i].magnitude;
            bonusType = sideBonuses[i].bonusType;
            if (bonusType != 0)
            {
                returnString = returnString + "\nSide " + i + 1 + " has bonus of " + bonusType + " with magnitude " + magnitude;
            }
        }
        return returnString;
    }

    public void ChangeSide(int side, BonusGoop action)
    {
        if (side >= 0 && side < numSides )
        {
            sideBonuses[side] = new BonusGoop(action.bonusType,action.gooStrength, action.dieRelation,action.description);
            sideBonuses[side].SetMagnitude(side);
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
        return new int[] {currentFace+1, (int)currentAction.bonusType, currentAction.magnitude};
    }

    void Merge(Die secondDie, Die thirdDie)
    {
        // TODO: Maybe merging?
        return;
    }
}
