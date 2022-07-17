using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BonusTypes
{
    None = 0,
    Poison = 1,
    Thorns = 2,
    DamageReduction = 3,
    Dodge = 4,
    Stun = 5,
    Strength = 6,
    MultiAttack = 7
};

[System.Serializable]
public class BonusGoop
{
    public BonusTypes bonusType;
    public int magnitude;
    public string description;
    public int dieRelation;
    public int gooStrength;

    public BonusGoop(BonusTypes bonus, int mag, int relation, string desc)
    {
        this.bonusType = bonus;
        this.gooStrength = mag;
        this.description = desc;
        this.dieRelation = relation;
        Debug.Log("goo strength " + this.gooStrength + " and die relation " + this.dieRelation);
    }

    public void SetMagnitude(int dieFace)
    {
        Debug.Log("goo strength " + this.gooStrength + " and die relation " + this.dieRelation);
        // We expect to be given the index of the dieface, not the actual value on the face ie. the face with 3 dots should have dieFace=2
        switch (this.dieRelation)
        {
            case 0: // magnitude is goo strength
                this.magnitude = this.gooStrength;
                break;
            case 1: // magnitude is goo strength * die value
                this.magnitude = this.gooStrength * (dieFace + 1);
                break;
            case 2: // magnitude is die value / die value
                this.magnitude = (int)(dieFace + 1) / this.gooStrength;
                break;
            case 3: // good idea but we aint using it yet because scope
                Debug.Log("you should really not be here");
                break;
        }
    }


}