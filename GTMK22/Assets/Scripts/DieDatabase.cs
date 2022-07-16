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
    public Effect[] effects;
    public static DieDatabase CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<DieDatabase>(jsonString);
    }

    public BonusGoop GetRandomGoop()
    {
        int bonus = UnityEngine.Random.Range(0, effects.Length - 1);
        int mag_ind = UnityEngine.Random.Range(0, effects[bonus].magnitudes.Length - 1);
        int mag = Int32.Parse(effects[bonus].magnitudes[mag_ind].value);
        string descript = Regex.Replace(effects[bonus].description, "{magnitude}", effects[bonus].magnitudes[mag_ind].description);
        return new BonusGoop((BonusTypes)bonus, mag, descript);
    }
}

[Serializable]
public class Effect
{
    public string name = "";
    public string caseNum = "";
    public string description = "";
    public Magnitude[] magnitudes;
}

[Serializable]
public class Magnitude
{
    public string dieRelation = "";
    public string value = "";
    public string description = "";
}
#endregion