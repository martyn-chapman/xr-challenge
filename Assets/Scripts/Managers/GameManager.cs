using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        Play,
        Win
    }
    public GameStates GameState { get; private set; }
    public event Action<GameStates> OnGameStateChanged;

    public PlayerManager PlayerManager { get; private set; }
    public UI_Manager UI_Manager { get; private set; }

    [SerializeField] private int _winCondition;
    public int WinCondition => _winCondition;


    protected override void Init()
    {
        PlayerManager = GetComponentInChildren<PlayerManager>();
        UI_Manager = GetComponentInChildren<UI_Manager>();
    }


    private void Start()
    {
        UpdateGameState(GameStates.Play);
    }


    public void UpdateGameState(GameStates state)
    {
        GameState = state;
        OnGameStateChanged?.Invoke(state);
    }
}