using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBoxCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.PlayerManager.GetItemsCounter() >= GameManager.Instance.WinCondition) // Check to see if player has picked up all items
                GameManager.Instance.UpdateGameState(GameManager.GameStates.Win);
        }

    }
}
