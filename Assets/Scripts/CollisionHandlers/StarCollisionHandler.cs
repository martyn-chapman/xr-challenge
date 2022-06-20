using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollisionHandler : MonoBehaviour
{
    private Pickup pickup;
    private float destroyTimer = 3.0f;


    private void Awake()
    {
        pickup = GetComponent<Pickup>();
    }


    /// <summary>
    /// Subscribing to the OnPickUp delegate needs to take place after normal Unity instantiation functions (Awake, OnEnable, etc) as Pickup.Init() is only ever called after these.
    /// </summary>
    private void SubscribeToEvents()
    {
        pickup.OnPickUp += GameManager.Instance.PlayerManager.UpdateScore;
        pickup.OnPickUp += GameManager.Instance.UI_Manager.UpdateScore;
    }


    private void UnsubscribeFromEvents()
    {
        pickup.OnPickUp -= GameManager.Instance.PlayerManager.UpdateScore;
        pickup.OnPickUp -= GameManager.Instance.UI_Manager.UpdateScore;
    }


    private void PlaySoundEffect()
    {
        float pitch = 0.5f + (GameManager.Instance.PlayerManager.GetItemsCounter() * (0.5f / GameManager.Instance.WinCondition)); // Change this audio clip's pitch based on how many items have already been picked up (will become higher pitched as player collects more items)
        GameManager.Instance.AudioManager.SetPitch("StarPickup", pitch);
        GameManager.Instance.AudioManager.Play("StarPickup");
    }


    private void CollisionResponse()
    {
        SubscribeToEvents();
        if (pickup.GetPickedUp() >= 0)
        {
            GameManager.Instance.PlayerManager.UpdateItemsCounter(1);
            PlaySoundEffect();
            Destroy(gameObject, destroyTimer);
            UnsubscribeFromEvents(); // Unsubscribe to events here when the Pickup has been set to be destroyed, as Unity can throw an error for not being able to find the GameManager instance on exit if called in OnDisable()
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollisionResponse();
        }
    }
}
