using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageVisualEffects : MonoBehaviour
{   
    public TextMeshPro baseDamageText;
    public TextMeshPro bonusDamageText;
    // private int baseDamage = 9000;
    // private int bonusType = 0;
    // private int bonusDamage = 1;
    public BonusTypes types; 
    public List<Color> effectColors;// = new Color[7];
    // Start is called before the first frame update
    void Start()
    {
        //textObject = thisBlock.transform.GetChild(1).gameObject;
        //var damageText = this.GetComponentsInChildren<TextMeshPro>();
        //Debug.Log("made it here with " + damageText);
        
        effectColors.Add(new Color(0.7764707f,0.2431373f,0.6352941f)); // pink
        effectColors.Add(new Color(0.2666667f,0.2f,0.3607843f)); // purple
        effectColors.Add(new Color(0.2980392f,0.3960785f,0.7843138f)); // blue
        effectColors.Add(new Color(0.8901961f,0.8431373f,0.227451f)); // yellow
        effectColors.Add(new Color(0.6f,0.8980393f,0.3137255f)); // green
        effectColors.Add(new Color(0.9490197f,0.5058824f,0.1843137f)); // orange
        effectColors.Add(new Color(0.6862745f,0.2313726f,0.2509804f)); // red
        UpdateDamageNumbers(6,4,2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateDamageNumbers(int baseDamage, int bonusType, int bonusDamage )
    {
    baseDamageText.text = baseDamage.ToString();
    bonusDamageText.text = bonusDamage.ToString();
    bonusDamageText.color = effectColors[bonusType];

    }

}




//raw damage (white damage #), bonus type(which color and icon), bonus effect (effect number)

