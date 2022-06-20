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

    public AudioManager AudioManager { get; private set; }
    public PlayerManager PlayerManager { get; private set; }
    public UI_Manager UI_Manager { get; private set; }
    public DogManager DogManager { get; private set; }


    protected override void Init()
    {
        AudioManager = GetComponentInChildren<AudioManager>();
        PlayerManager = GetComponentInChildren<PlayerManager>();
        UI_Manager = GetComponentInChildren<UI_Manager>();
        DogManager = GetComponentInChildren<DogManager>();
    }


    private void Start()
    {
        // Base the win condition on the total amount of star pickups in the level
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("StarPickup");
        WinCondition = pickups.Length;

        UpdateGameState(GameStates.Play);
    }


    // (Dirty) Prevents Unity from throwing NullReferenceException when scripts attempt to unsubscribe from delegates on quit. Ensures that each script is disabled, running their OnDisable functions, before any objects are destroyed.
    private void OnApplicationQuit()
    {
        MonoBehaviour[] scripts = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
            script.enabled = false;
    }


    public void UpdateGameState(GameStates state)
    {
        GameState = state;
        OnGameStateChanged?.Invoke(state);
    }
}