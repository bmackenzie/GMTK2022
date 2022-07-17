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

        
    public void OnDrop(PointerEventData eventData)
    {
    return;

    // This could be location for handoff between shop faces added and die info
    }

    public void OnDestroy()
    {
        FindObjectOfType<Player>().UpdateDieDetails(numSides, slimeDetails);
    }
}
