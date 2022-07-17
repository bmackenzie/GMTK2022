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

    private Die slimeDetails;

    void Awake()
    {
        slimeDetails = slime.slimeDetails;
        try
        {
            desc1.text = slimeDetails.sideBonuses[0].description;
            slot1.interactable = false;

        }
        catch
        {
            desc1.text = "empty";
        }

        try
        {
            desc2.text = slimeDetails.sideBonuses[1].description;
            slot2.interactable = false;
        }
        catch
        {
            desc2.text = "empty";
        }

        try
        {
            desc3.text = slimeDetails.sideBonuses[2].description;
            slot3.interactable = false;
        }
        catch
        {
            desc3.text = "empty";
        }

        try
        {
            desc4.text = slimeDetails.sideBonuses[3].description;
            slot4.interactable = false;
        }
        catch
        {
            desc4.text = "empty";
        }

    }

    public void OpenMenu()
    {
        desc1.text = slimeDetails.sideBonuses[0].description;
    }


    public void CloseMenu()
    {
        gameObject.SetActive(false);
        slimeDetails = slime.slimeDetails;
    }
}
