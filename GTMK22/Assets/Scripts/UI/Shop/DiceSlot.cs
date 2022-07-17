using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceSlot : MonoBehaviour, IDropHandler
{
    public int numSides;
    public TMPro.TMP_Text hoverTextObject;
    private Die slimeDetails;

    void Awake()
    {
        this.slimeDetails = FindObjectOfType<Player>().GetDieDetails(numSides);
        hoverTextObject.text = this.slimeDetails.GetFaceInfo();

    }
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
