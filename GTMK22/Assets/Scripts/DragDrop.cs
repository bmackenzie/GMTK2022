using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 startPosition;
    private GameObject startParent;
    private bool onDropZone = false;
    private GameObject slot;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startParent = transform.parent.gameObject;
        
    }

    public void SetDropZone()
    {
        onDropZone = true;
    }

    public void SetSlot(GameObject go)
    {
        slot = go;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        try
        {
            slot.GetComponent<ExchangeSlot>().Unoccupy();
        }
        catch
        {
            Debug.Log("not in exchange slot");
        }
        canvasGroup.blocksRaycasts = false;
        onDropZone = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (!onDropZone)
        {
            Reset();
        }
    }

    public void Reset()
    {
        transform.parent = startParent.transform;
        rectTransform.anchoredPosition = startPosition;
        slot = transform.parent.gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
