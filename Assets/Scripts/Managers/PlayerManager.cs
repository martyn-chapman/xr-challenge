using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject cameraObject;

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


    public Transform GetPlayerTransform()
    {
        return playerObject.transform;
    }


    public Transform GetCameraTransform()
    {
        return cameraObject.transform;
    }


    public Vector3 GetPlayerPosition()
    {
        return playerObject.transform.position;
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
