using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : Singleton<UI_Manager>
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject winPanel;


    override protected void Init()
    {
        scoreText.gameObject.SetActive(true);
        winPanel.SetActive(false);
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManagerOnGameStateChanged;
    }


    private void OnDisable()
    {
        GameManager.Instance.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }


    private void GameManagerOnGameStateChanged(GameManager.GameStates state)
    {
        switch (state) // Set which UI elements to be active depending on current game state
        {
            case GameManager.GameStates.Play:
                scoreText.gameObject.SetActive(true);
                winPanel.SetActive(false);
                break;
            case GameManager.GameStates.Win:
                winPanel.SetActive(true);
                break;
            default:
                break;
        }
    }


    public void UpdateScore(Pickup pickup)
    {
        scoreText.text = "SCORE: " + GameManager.Instance.PlayerManager.GetScore();
    }
}
