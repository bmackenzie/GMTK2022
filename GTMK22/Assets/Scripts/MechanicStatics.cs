using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BonusTypes
{
    None = -1,
    Dmgx2,
    idkbro
};


public struct BonusGoop
{
    public BonusTypes bonusType;
    public int magnitude;

    public BonusGoop(int mag)
    {
        bonusType = (BonusTypes)Random.Range(0, System.Enum.GetValues(typeof(BonusTypes)).Length - 2);
        magnitude = mag;
    }

    public BonusGoop(BonusTypes bonus, int mag)
    {
        bonusType = bonus;
        magnitude = mag;
    }
}