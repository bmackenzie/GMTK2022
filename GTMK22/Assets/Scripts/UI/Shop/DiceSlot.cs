using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiceSlot : MonoBehaviour, IDropHandler
{
    public int numSides;
    private Die slimeDetails;

    void Awake()
    {
        slimeDetails = FindObjectOfType<Player>().GetDieDetails(numSides);

    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            Destroy(eventData.pointerDrag);
        }
    }

    public void OnDestroy()
    {
        FindObjectOfType<Player>().UpdateDieDetails(numSides, slimeDetails);
    }
}
