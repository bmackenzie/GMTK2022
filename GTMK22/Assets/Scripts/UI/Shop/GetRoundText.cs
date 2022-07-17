using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRoundText : MonoBehaviour
{
    private int roundNum = 0;
    private void Awake()
    {
        var textContainer = GetComponent<TMPro.TMP_Text>();
        roundNum = FindObjectOfType<GameManager>().rounds;
        textContainer.text = (roundNum - 1).ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
