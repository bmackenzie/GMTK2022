using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health { get; private set; }
    public int lives { get; private set; }
    public int money { get; private set; }
    public int maxDice { get; private set; }
    public List<Die> dice { get; private set; }
   

    public void ChangeHealth(int changeValue)
    {
        health += changeValue;
        if( health <= 0)
        {
            PlayerDeath();
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
