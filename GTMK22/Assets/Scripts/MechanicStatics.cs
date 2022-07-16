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

    public BonusGoop(BonusTypes bonus, int mag, string desc)
    {
        bonusType = bonus;
        magnitude = mag;
        description = desc;
    }
}