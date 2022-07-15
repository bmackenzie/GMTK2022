using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public SceneLoader sceneLoader;
    public Player playerPrefab;
    public Player player;
    

    private void Awake()
    {
        this.dialogueRunner = this.GetComponentInChildren<DialogueRunner>();
        this.sceneLoader = this.GetComponent<SceneLoader>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Setup a splash screen
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        // Load Gameplay Scene assets
        // instantiate a player

        this.player = Instantiate(playerPrefab);
        this.dialogueRunner.StartDialogue("Start");
        // TODO: Add a name input?
        
    }

    public void StartBattle()
    {
        // TODO: Instantiate an enemy

        sceneLoader.LoadSpecificScene("CombatScene");
    }
    public void EndBattle(bool victory)
    {

        //if(victory)
        //{

        //}
    }

    public void GoToTitle()
    {
        sceneLoader.Restart();
    }
}
