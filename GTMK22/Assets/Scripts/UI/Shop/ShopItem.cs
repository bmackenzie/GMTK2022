using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Image exchangePanel;
    [SerializeField] private Image exchangeSlot;

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

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void ShowPanel()
    {
        if (exchangePanel.transform.gameObject.activeSelf == false)
        {
            //exchangePanel.transform.gameObject.SetActive(true);
            //transform.parent = exchangeSlot.transform;
            //GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            //transform.parent.parent.GetComponent<ExchangePanel>().SetRecieve(gameObject);
        }
        else
        {
            Debug.Log("nothing");
        }
    }

    public void Reset()
    {
        transform.parent = startParent.transform;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
}
