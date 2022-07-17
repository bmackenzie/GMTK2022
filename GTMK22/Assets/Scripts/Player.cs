using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    public int health { get; private set; }
    public int maxHealth { get; private set; }
    public int lives = 3;
    public int maxLives { get; private set; }
    public int money { get; private set; }
    public int maxDice = 3;
    public List<Die> dice;
    public List<BonusGoop> bits;
    private DieDatabase dieDatabase = new DieDatabase();


    public void Awake()
    {
        
        money = 0;
        maxHealth = 50;
        maxLives = 6;
        ChangeHealth(maxHealth);
        //ChangeLives(maxLives);
        // Pick up a random starting bit
        this.bits.Add(dieDatabase.GetRandomGoop());
    }
    void Start()
    {
        // maxHealth = 100;
        // ChangeHealth(maxHealth);
        // dice.Add(new Die(4));
    }

    public bool ChangeHealth(int changeValue)
    {
        health += changeValue;
        if( health <= 0)
        {
            PlayerDeath();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeLives(int changeValue)
    {
        lives += changeValue;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public bool ChangeMoney(int changeValue)
    {
        if (money + changeValue < 0)
        {
            return false;
        }
        else
        {
            money += changeValue;
            return true;
        }
    }

    public Die GetDieDetails(int numSides)
    {
        foreach(Die die in this.dice)
        {
            if(die.numSides == numSides)
            {
                return die;
            }
        }
        return null;
    }

    public void UpdateDieDetails(int numSides, Die newDetails)
    {
        for(int i = 0; i < this.dice.Count; i++)
        {
            if(this.dice[i].numSides == numSides)
            {
                this.dice[i] = newDetails;
            }
        }
    }
    public void AddDie(Die newDie, int position)
    {
        if (position > maxDice -1)
        {
            Debug.Log("position out of range");
            return;
        }

        if (dice[position] != null)
        {
            RemoveDie(position);
        }

        dice.Insert(position, newDie);
    }

    public void RemoveDie(int position)
    {
        dice.RemoveAt(position);
    }

    public void GameOver()
    {
        //call sceneloader to load gameover scene
    }

    public void PlayerDeath()
    {
        //TODO: DIE DIE DIE DIE
        ChangeLives(-1);
        return;
    }

}
