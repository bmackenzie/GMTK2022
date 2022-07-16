using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangePanel : MonoBehaviour
{
    [SerializeField] private GameObject giveSlot1;
    [SerializeField] private GameObject giveSlot2;
    [SerializeField] private GameObject recieveSlot;
    [SerializeField] private DragDrop[] faces;

    void Awake()
    {
        faces = FindObjectsOfType<DragDrop>();
    }

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
        Debug.Log(face);
        recieveSlot = face;
        
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        try
        {
            recieveSlot.GetComponent<ShopItem>().Reset();
        }
        catch
        {
            Debug.Log("no recieve item");
        }

        foreach (DragDrop face in faces)
        {
            face.Reset();
        }
        
        giveSlot1 = null;
        giveSlot2 = null;
        recieveSlot = null;
    }

}
