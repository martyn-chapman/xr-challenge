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
    public int WinCondition { get; private set; }
    public event Action<GameStates> OnGameStateChanged;

    public PlayerManager PlayerManager { get; private set; }
    public UI_Manager UI_Manager { get; private set; }


    protected override void Init()
    {
        PlayerManager = GetComponentInChildren<PlayerManager>();
        UI_Manager = GetComponentInChildren<UI_Manager>();

        // Base the win condition on the total amount of star pickups in the level
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("StarPickup");
        WinCondition = pickups.Length;
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