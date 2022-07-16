using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Image exchangePanel;
    [SerializeField] private Image exchangeSlot;
    private GameObject startParent;

    void Awake()
    {
        startParent = transform.parent.gameObject;
    }

    public void ShowPanel()
    {
        if (exchangePanel.transform.gameObject.activeSelf == false)
        {
            exchangePanel.transform.gameObject.SetActive(true);
            transform.parent = exchangeSlot.transform;
            GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            transform.parent.parent.GetComponent<ExchangePanel>().SetRecieve(gameObject);
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
