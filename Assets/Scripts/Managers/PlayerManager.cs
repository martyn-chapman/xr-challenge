using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    private int score = 0;

    public int GetScore()
    {
        return score;
    }

    public void UpdateScore(Pickup pickup)
    {
        score += pickup.ScoreValue;
    }
}
