using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceSlot : MonoBehaviour, IDropHandler
{
    public int numSides;
    public GameObject hoverTextObject;
    private Die slimeDetails;

    void Awake()
    {
        slimeDetails = FindObjectOfType<Player>().GetDieDetails(numSides);
        hoverTextObject.GetComponent<Text>().text = slimeDetails.GetFaceInfo();

    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            Destroy(eventData.pointerDrag);
            hoverTextObject.GetComponent<Text>().text = slimeDetails.GetFaceInfo();
        }
    }

    public void OnDestroy()
    {
        FindObjectOfType<Player>().UpdateDieDetails(numSides, slimeDetails);
    }
}
