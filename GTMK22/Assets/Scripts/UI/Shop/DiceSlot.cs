using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceSlot : MonoBehaviour, IDropHandler
{
    public int numSides;
    public TMPro.TMP_Text hoverTextObject;
    public Die slimeDetails;

    void Awake()
    {
        this.slimeDetails = FindObjectOfType<Player>().GetDieDetails(numSides);
        hoverTextObject.text = this.slimeDetails.GetFaceInfo();
    }


    // add in order of die to slime details to be read in battle manager

        
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            Destroy(eventData.pointerDrag);
            hoverTextObject.text = this.slimeDetails.GetFaceInfo();
        }
    }

    public void OnDestroy()
    {
        FindObjectOfType<Player>().UpdateDieDetails(numSides, slimeDetails);
    }
}
