using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlimeFaceSlot : MonoBehaviour, IDropHandler
{
    private bool isOccupied = false;

    public void Unoccupy()
    {
        //Do nothing for slimes
        return;
    }

    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null & !isOccupied)
        {
            if(eventData.pointerDrag.GetComponent<RenderFaceEffectIcon>() != null)
            {
                eventData.pointerDrag.GetComponent<DragDrop>().SetDropZone();
                eventData.pointerDrag.transform.parent = this.transform;
                eventData.pointerDrag.GetComponent<DragDrop>().SetSlot(gameObject);
            }
        }
    }
}
