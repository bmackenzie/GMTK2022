using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    //public TextAsset jsonFile;
    public DialogueRunner dialogueRunner;
    public SceneLoader sceneLoader;
    public Player playerPrefab;
    public Player player;
    //public static string jsonthing;
    public int rounds { get; private set; }

    //[SerializeField] private string[] dialogueNodes;

    //[MenuItem("AssetDatabase/LoadAssetExample")]
    private void Awake()
    {
        this.dialogueRunner = this.GetComponentInChildren<DialogueRunner>();
        this.sceneLoader = this.GetComponent<SceneLoader>();
        rounds = 1;
    ///jsonthing = (string)AssetDatabase.LoadAssetAtPath("Assets/JsonData/DieFaces.json", typeof(string));
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

        if (victory)
        {
            
            this.dialogueRunner.StartDialogue("BattleEnd");
            
            rounds++;
            if (rounds <= 10)
            {
                GoToShop();
            }
            else
            {
                GoToCredits();
            }
        }
        else
        {
            this.dialogueRunner.StartDialogue("LoseDialog");
            if (player.lives <= 0)
            {
                GoToTitle();
            }
            else
            {
                Debug.Log("Should be going to the shop");
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

    public void GoToCredits()
    {
        sceneLoader.LoadSpecificScene("Credits");
    }
}
