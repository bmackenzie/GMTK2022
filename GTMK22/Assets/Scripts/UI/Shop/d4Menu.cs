using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class d4Menu : MonoBehaviour
{
    [SerializeField] private DiceSlot slime;
    [SerializeField] private Button slot1;
    [SerializeField] private Button slot2;
    [SerializeField] private Button slot3;
    [SerializeField] private Button slot4;
    [SerializeField] private TMPro.TMP_Text desc1;
    [SerializeField] private TMPro.TMP_Text desc2;
    [SerializeField] private TMPro.TMP_Text desc3;
    [SerializeField] private TMPro.TMP_Text desc4;
    private GameObject activeFace;

    [SerializeField] private Die slimeDetails;

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
    }

    public void OpenMenu(GameObject active)
    {
        activeFace = active;
        RedrawMenu();
    }


    public void CloseMenu()
    {
        gameObject.SetActive(false);
        slimeDetails = slime.slimeDetails;
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

    void UpdateFace(int position)
    {
        Debug.Log("firing");
        //slimeDetails.sideBonuses[position] = activeFace.GetComponent<RenderFaceEffectIcon>().faceEffect;
        //slimeDetails.sideBonuses[position].SetMagnitude(position);
        slimeDetails.ChangeSide(position, activeFace.GetComponent<RenderFaceEffectIcon>().faceEffect);
        Destroy(activeFace);
        CloseMenu();
    }
}
