using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeActivator : MonoBehaviour
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
        exchangePanel.transform.gameObject.SetActive(true);
        transform.parent = exchangeSlot.transform;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
}
