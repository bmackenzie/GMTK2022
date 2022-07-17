using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderFaceEffectIcon : MonoBehaviour
{
    public BonusGoop faceEffect { get; private set; }
    public Sprite[] faceEffectIconList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeEmpty()
    {
        faceEffect = null;
        GetComponent<Image>().color = Color.black;
    }

    public void UpdateFaceEffect(BonusGoop newEffect)
    {
        faceEffect = newEffect;
        GetComponent<Image>().sprite = faceEffectIconList[(int)faceEffect.bonusType - 1];
        GetComponent<ToolTip>().tooltipContainer.GetComponentInChildren<TMPro.TMP_Text>().text = faceEffect.description;
    }

    public void UpdateCombatEffectShadow(int bnsType)
    {
        GetComponent<SpriteRenderer>().sprite = faceEffectIconList[bnsType - 1];
        GetComponent<SpriteRenderer>().color = Color.black;
        //GetComponent<SpriteRenderer>().transform.position += new Vector3(.1f, 0, 0);
    }

    public void UpdateCombatEffect(int bnsType)
    {
        GetComponent<SpriteRenderer>().sprite = faceEffectIconList[bnsType - 1];
    }
}
