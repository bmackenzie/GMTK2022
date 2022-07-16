using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangePanel : MonoBehaviour
{
    [SerializeField] private GameObject giveSlot1;
    [SerializeField] private GameObject giveSlot2;
    [SerializeField] private GameObject recieveSlot;

    public void SetGiveOne(GameObject face)
    {
        giveSlot1 = face;
    }

    public void SetGiveTwo(GameObject face)
    {
        giveSlot2 = face;
    }

    public void SetRecieve(GameObject face)
    {
        recieveSlot = face;
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

}
