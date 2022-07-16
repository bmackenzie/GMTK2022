using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public SceneLoader sceneLoader;
    public Player playerPrefab;
    public Player player;

    public int rounds { get; private set; }


    private void Awake()
    {
        this.dialogueRunner = this.GetComponentInChildren<DialogueRunner>();
        this.sceneLoader = this.GetComponent<SceneLoader>();
        //AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/JsonData/DieFaces.json").text
        //public DieDatabase DieLibrary = DieDatabase.CreateFromJSON();
        rounds = 1;
    }
        


    // Start is called before the first frame update
    void Start()
    {
        // Setup a splash screen
        this.StartGame();
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
        this.StartBattle();
    }

    public void StartBattle()
    {
        // TODO: Instantiate an enemy

        sceneLoader.LoadSpecificScene("CombatScene");
    }
    public void EndBattle(bool victory)
    {

        if(victory)
        {
            rounds++;
            this.dialogueRunner.StartDialogue("SecondDialog");
            GoToShop();
        }
        else
        {
            this.dialogueRunner.StartDialogue("LoseDialog");
            if(player.lives <= 0)
            {
                GoToTitle();
            }
            else
            {
                GoToShop();
            }
        }
    }

    public void GoToTitle()
    {
        sceneLoader.Restart();
    }

    public void GoToShop()
    {
        sceneLoader.LoadSpecificScene("shop");
    }
}
