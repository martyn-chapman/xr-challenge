using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    private int score = 0;
    private int itemsCounter = 0;

    public int GetScore()
    {
        return score;
    }

    public int GetItemsCounter()
    {
        return itemsCounter;
    }

    public void UpdateScore(Pickup pickup)
    {
        score += pickup.ScoreValue;
    }

    public void UpdateItemsCounter(int value)
    {
        itemsCounter += value;
    }
}
