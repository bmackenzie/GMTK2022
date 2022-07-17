using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceSlot : MonoBehaviour, IDropHandler
{
    public int numSides;
    public TMPro.TMP_Text hoverTextObject;
    public Die slimeDetails;
    [SerializeField] private GameObject faceSetMenu;

    void Awake()
    {
        this.slimeDetails = FindObjectOfType<Player>().GetDieDetails(numSides);
        hoverTextObject.text = this.slimeDetails.GetFaceInfo();
    }

        
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("ping");
            switch (numSides)
            {
                case 4:
                    d4Menu menu = faceSetMenu.GetComponent<d4Menu>();
                    menu.gameObject.SetActive(true);
                    menu.OpenMenu(eventData.pointerDrag);
                    break;
                case 6:
                    d6Menu menu2= faceSetMenu.GetComponent<d6Menu>();
                    menu2.gameObject.SetActive(true);
                    menu2.OpenMenu(eventData.pointerDrag);
                    break;
                default:
                    d8Menu menu3 = faceSetMenu.GetComponent<d8Menu>();
                    menu3.gameObject.SetActive(true);
                    menu3.OpenMenu(eventData.pointerDrag);
                    break;
            }

            eventData.pointerDrag.GetComponent<DragDrop>().Reset();
            hoverTextObject.text = this.slimeDetails.GetFaceInfo();
        }

        // This could be location for handoff between shop faces added and die info
    }

    public void OnDestroy()
    {
        FindObjectOfType<Player>().UpdateDieDetails(numSides, slimeDetails);
    }
}
