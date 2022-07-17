using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class d8Menu : MonoBehaviour
{
    [SerializeField] private DiceSlot slime;
    [SerializeField] private Button slot1;
    [SerializeField] private Button slot2;
    [SerializeField] private Button slot3;
    [SerializeField] private Button slot4;
    [SerializeField] private Button slot5;
    [SerializeField] private Button slot6;
    [SerializeField] private Button slot7;
    [SerializeField] private Button slot8;
    [SerializeField] private TMPro.TMP_Text desc1;
    [SerializeField] private TMPro.TMP_Text desc2;
    [SerializeField] private TMPro.TMP_Text desc3;
    [SerializeField] private TMPro.TMP_Text desc4;
    [SerializeField] private TMPro.TMP_Text desc5;
    [SerializeField] private TMPro.TMP_Text desc6;
    [SerializeField] private TMPro.TMP_Text desc7;
    [SerializeField] private TMPro.TMP_Text desc8;
    private GameObject activeFace;

    private Die slimeDetails;

    void Awake()
    {
        slimeDetails = slime.slimeDetails;
        RedrawMenu();
    }

    void RedrawMenu()
    {
        desc1.text = slimeDetails.sideBonuses[0].description;
        if (slimeDetails.sideBonuses[0].description != "nothing fancy")
        {
            slot1.interactable = false;

        }

        desc2.text = slimeDetails.sideBonuses[1].description;
        if (slimeDetails.sideBonuses[1].description != "nothing fancy")
        {
            slot2.interactable = false;

        }

        desc3.text = slimeDetails.sideBonuses[2].description;
        if (slimeDetails.sideBonuses[2].description != "nothing fancy")
        {
            slot3.interactable = false;

        }

        desc4.text = slimeDetails.sideBonuses[3].description;
        if (slimeDetails.sideBonuses[3].description != "nothing fancy")
        {
            slot4.interactable = false;

        }

        desc5.text = slimeDetails.sideBonuses[4].description;
        if (slimeDetails.sideBonuses[4].description != "nothing fancy")
        {
            slot5.interactable = false;

        }

        desc6.text = slimeDetails.sideBonuses[5].description;
        if (slimeDetails.sideBonuses[5].description != "nothing fancy")
        {
            slot6.interactable = false;

        }

        desc7.text = slimeDetails.sideBonuses[6].description;
        if (slimeDetails.sideBonuses[6].description != "nothing fancy")
        {
            slot7.interactable = false;

        }

        desc8.text = slimeDetails.sideBonuses[7].description;
        if (slimeDetails.sideBonuses[7].description != "nothing fancy")
        {
            slot8.interactable = false;

        }
    }

    public void OpenMenu(GameObject active)
    {
        activeFace = active;
        RedrawMenu();
    }


    public void CloseMenu()
    {
        gameObject.SetActive(false);
        slime.slimeDetails = slimeDetails;
        slime.UpdateHoverText();
    }

    public void Slot1Click()
    {
        UpdateFace(0);
    }

    public void Slot2Click()
    {
        UpdateFace(1);
    }

    public void Slot3Click()
    {
        UpdateFace(2);
    }

    public void Slot4Click()
    {
        UpdateFace(3);
    }

    public void Slot5Click()
    {
        UpdateFace(4);
    }

    public void Slot6Click()
    {
        UpdateFace(5);
    }

    public void Slot7Click()
    {
        UpdateFace(6);
    }

    public void Slot8Click()
    {
        UpdateFace(7);
    }

    void UpdateFace(int position)
    {
        //update the die with the ActiveFace GameObject
        //slimeDetails.sideBonuses[position] = activeFace.GetComponent<RenderFaceEffectIcon>().faceEffect;
        //slimeDetails.sideBonuses[position].SetMagnitude(position);
        slimeDetails.ChangeSide(position, activeFace.GetComponent<RenderFaceEffectIcon>().faceEffect);
        FindObjectOfType<Player>().RemoveInventoryItem(activeFace.GetComponent<RenderFaceEffectIcon>().faceEffect);
        Destroy(activeFace);
        CloseMenu();
    }
}
