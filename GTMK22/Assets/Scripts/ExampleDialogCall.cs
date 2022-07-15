using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;

public class ExampleDialogCall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!FindObjectOfType<Yarn.Unity.DialogueRunner>().IsDialogueRunning)
        {
            CallADialogue("SecondDialog");
        }
    }

    void CallADialogue(string nodeTitle)
    {
        FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue(nodeTitle);
    }
}
