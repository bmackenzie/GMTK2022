using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRoundText : MonoBehaviour
{
    private int roundNum = 0;
    private void Awake()
    {
        roundNum = FindObjectOfType<GameManager>().rounds;
        GetComponent<Text>().text = (roundNum - 1).ToString();
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
