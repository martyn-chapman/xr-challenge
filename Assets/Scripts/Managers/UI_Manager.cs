using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : Singleton<UI_Manager>
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void UpdateScore(Pickup pickup)
    {
        scoreText.text = "SCORE: " + GameManager.Instance.PlayerManager.GetScore();
    }
}
