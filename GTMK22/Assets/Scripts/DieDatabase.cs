using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


#region DieDatabases
[Serializable]
public class DieDatabase
{
    //public int count;

    public Effect[] effects = { new Effect("Poison", "Add {magnitude} poison to the enemy", new Magnitude[2] { new Magnitude(0, 3, "3"), new Magnitude(1, 1, "die value") }),
        new Effect("Thorn", "Deal {magnitude} more damage when you are hit for the rest of the fight",new Magnitude[2] { new Magnitude(0, 2, "2"),
        new Magnitude(2, 2, "die value/2 (rounded down)")}),
        new Effect("Damage Reduction", "Reduce the damage of the next attack by {magnitude}", new Magnitude[2] { new Magnitude(0, 2, "2"),
        new Magnitude(2, 2, "die value/2 (rounded down)") }),
        new Effect("Dodge", "Avoid the next {magnitude} hit completely", new Magnitude[2] { new Magnitude(0, 1, "1"), new Magnitude(2, 3, "die value/3 (rounded down)") }),
        new Effect("Stun", "Deal {magnitude} additional damage, but skip your next turn", new Magnitude[2] { new Magnitude(0, 8, "8"), new Magnitude(1, 2, "2Xdie value") }),
        new Effect("Strength", "Deal {magnitude} more damage with every hit", new Magnitude[2] { new Magnitude(0, 2, "2"), new Magnitude(2, 2, "die value/2") }),
        new Effect("MultiAttack", "Deal {magnitude}", new Magnitude[2] { new Magnitude(0, 2, "dice damage twice this turn"), new Magnitude(3, 2, "(dice damage - 2) three times this turn") })};



public BonusGoop GetRandomGoop()
    {
        int bonus = UnityEngine.Random.Range(0, effects.Length - 1);
        int mag_ind = UnityEngine.Random.Range(0, effects[bonus].magnitudes.Length - 1);
        int mag = effects[bonus].magnitudes[mag_ind].value;
        string descript = Regex.Replace(effects[bonus].description, "{magnitude}", effects[bonus].magnitudes[mag_ind].description);
        return new BonusGoop((BonusTypes)bonus, mag, descript);
    }
}

[Serializable]
public class Effect
{
    public string name = "";
    public string description = "";
    public Magnitude[] magnitudes;

    public Effect(string nam, string desc, Magnitude[] mags)
    {
        name = nam;
        description = desc;
        magnitudes = mags;
    }
}

[Serializable]
public class Magnitude
{
    public int dieRelation;
    public int value;
    public string description;

    public Magnitude(int rel, int val, string desc)
    {
        dieRelation = rel;
        description = desc;
        value = val;
    }
}
#endregion
