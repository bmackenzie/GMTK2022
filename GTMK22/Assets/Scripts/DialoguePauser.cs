using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialoguePauser : MonoBehaviour
{
    protected bool isPaused = false;
    private DialogueRunner dialogueRunner;
    // Start is called before the first frame update
    void OnEnable()
    {
        this.dialogueRunner = FindObjectOfType<DialogueRunner>();
        this.isPaused = this.dialogueRunner.IsDialogueRunning;
        this.dialogueRunner.onNodeStart.AddListener(OnDialogStart);
        this.dialogueRunner.onDialogueComplete.AddListener(OnDialogComplete);
    }

    private void OnDisable()
    {
        this.dialogueRunner.onNodeStart.RemoveListener(OnDialogStart);
        this.dialogueRunner.onDialogueComplete.RemoveListener(OnDialogComplete);
    }

    private void OnDialogStart(string node)
    {
        isPaused = true;
    }

    private void OnDialogComplete()
    {
        isPaused = false;
    }
}
