using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public TextAsset jsonFile;
    public DialogueRunner dialogueRunner;
    public SceneLoader sceneLoader;
    public Player playerPrefab;
    public Player player;
    public static string jsonthing;
    public int rounds { get; private set; }

    [SerializeField] private string[] dialogueNodes;

    [MenuItem("AssetDatabase/LoadAssetExample")]
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
            switch (rounds)
            {
                case 1:
                    this.dialogueRunner.StartDialogue(dialogueNodes[0]);
                    break;
                case 4:
                    this.dialogueRunner.StartDialogue(dialogueNodes[1]);
                    break;
                case 8:
                    this.dialogueRunner.StartDialogue(dialogueNodes[2]);
                    break;
                case 9:
                    this.dialogueRunner.StartDialogue(dialogueNodes[3]);
                    break;
                case 10:
                    this.dialogueRunner.StartDialogue(dialogueNodes[4]);
                    break;
                default:
                    this.dialogueRunner.StartDialogue("BattleEnd");
                    break;
            }
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
