using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEditor;

public class GameManager : DialoguePauser
{
    //public TextAsset jsonFile;
    //public DialogueRunner dialogueRunner;
    public SceneLoader sceneLoader;
    public Player playerPrefab;
    public Player player;
    public GameObject dialogueEventSystem;
    //public static string jsonthing;
    public int rounds { get; private set; }
    private bool goToShop = false;
    private bool goToBattle = false;
    private bool goToTitle = false;
    private bool goToCredits = false;

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
        if(isPaused)
        {
            return;
        }
        dialogueEventSystem.gameObject.SetActive(false);
        if (goToShop)
        {
            GoToShop();
            goToShop = false;
        }
        if(goToBattle)
        {
            StartBattle();
            goToBattle = false;
        }
        if(goToTitle)
        {
            GoToTitle();
        }
        if(goToCredits)
        {
            GoToCredits();
        }
    }

    public void StartGame()
    {
        // Load Gameplay Scene assets
        // instantiate a player

        this.player = Instantiate(playerPrefab);
        dialogueEventSystem.gameObject.SetActive(true);
        this.dialogueRunner.StartDialogue("Start");
        // TODO: Add a name input?
        this.StartBattle();
    }

    public void StartBattle()
    {
        // TODO: Instantiate an enemy
        this.player.ShowSlimes();
        sceneLoader.LoadSpecificScene("CombatScene");
        dialogueEventSystem.gameObject.SetActive(true);
        this.dialogueRunner.StartDialogue("BattleStart");
        
    }
    public void EndBattle(bool victory)
    {

        if (victory)
        {
            dialogueEventSystem.gameObject.SetActive(true);
            this.dialogueRunner.StartDialogue("BattleEnd");

            
            rounds++;
            
            if (rounds <= 10)
            {
                //GoToShop();
                goToShop = true;
            }
            else
            {
                //GoToCredits();
                goToCredits = true;
            }
        }
        else
        {
            
            if (player.lives <= 0)
            {
                dialogueEventSystem.gameObject.SetActive(true);
                this.dialogueRunner.StartDialogue("GameOver");
                //GoToTitle();
                goToTitle = true;
            }
            else
            {
                dialogueEventSystem.gameObject.SetActive(true);
                this.dialogueRunner.StartDialogue("LoseDialog");
                goToShop = true;
                //Debug.Log("Should be going to the shop");
                //GoToShop();
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
        this.player.HideSlimes();
        dialogueEventSystem.gameObject.SetActive(true);
        this.dialogueRunner.StartDialogue("SetupStart");
    }

    public void GoToCredits()
    {
        sceneLoader.LoadSpecificScene("Credits");
    }
}
