using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExchangeSlot : MonoBehaviour, IDropHandler
{
    private bool isOccupied = false;

    public void Unoccupy()
    {
        isOccupied = false;
    }

    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null & !isOccupied)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().SetDropZone();
            eventData.pointerDrag.transform.parent = this.transform;
            eventData.pointerDrag.GetComponent<DragDrop>().SetSlot(gameObject);
            isOccupied = true;
            transform.parent.GetComponent<ExchangePanel>().SetGiveOne(eventData.pointerDrag);
        }
    }
}
