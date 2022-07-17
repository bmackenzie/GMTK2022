using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField] public Image tooltipContainer;

    public void ShowToolTip()
    {
        tooltipContainer.transform.gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        tooltipContainer.transform.gameObject.SetActive(false);
    }
}
