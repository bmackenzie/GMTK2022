using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageVisualEffects : MonoBehaviour
{   
    public TextMeshPro baseDamageText;
    public TextMeshPro bonusDamageText;
    public TextMeshPro baseDamageShadowText;
    public TextMeshPro bonusDamageShadowText;

    public BonusTypes types; 
    public List<Color> effectColors;
    public RenderFaceEffectIcon renderFaceEffecIcon;
    public RenderFaceEffectIcon renderFaceEffecIconShadow;
    
    void Start()
    {
        //textObject = thisBlock.transform.GetChild(1).gameObject;
        //var damageText = this.GetComponentsInChildren<TextMeshPro>();
        //Debug.Log("made it here with " + damageText);
        //renderFaceEffecIcon = FindObjectOfType<RenderFaceEffectIcon>();
        
        effectColors.Add(new Color(1.0f,1.0f,1.0f)); // white
        effectColors.Add(new Color(0.7764707f,0.2431373f,0.6352941f)); // pink
        effectColors.Add(new Color(0.2666667f,0.2f,0.3607843f)); // purple
        effectColors.Add(new Color(0.2980392f,0.3960785f,0.7843138f)); // blue
        effectColors.Add(new Color(0.8901961f,0.8431373f,0.227451f)); // yellow
        effectColors.Add(new Color(0.6f,0.8980393f,0.3137255f)); // green
        effectColors.Add(new Color(0.9490197f,0.5058824f,0.1843137f)); // orange
        effectColors.Add(new Color(0.6862745f,0.2313726f,0.2509804f)); // red
        //UpdateDamageNumbers(6,4,2);
    }

    void Update()
    {
        
    }


    public void UpdateDamageNumbers(int baseDamage, int bonusType, int bonusDamage )
    {
    Debug.Log(baseDamage + bonusType + bonusDamage);
    baseDamageShadowText.text = baseDamage.ToString();
    bonusDamageShadowText.text = bonusDamage.ToString();
    baseDamageText.text = baseDamage.ToString();
    bonusDamageText.text = bonusDamage.ToString();
    bonusDamageText.color = effectColors[bonusType];
    renderFaceEffecIconShadow.UpdateCombatEffectShadow(bonusType-1);
    renderFaceEffecIcon.UpdateCombatEffect(bonusType-1);


    }

}




//raw damage (white damage #), bonus type(which color and icon), bonus effect (effect number)

