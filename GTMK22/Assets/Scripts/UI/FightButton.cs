using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightButton : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    public void LoadBattle()
    {
        gameManager.StartBattle();
    }
}
