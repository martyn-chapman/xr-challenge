using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private Pickup pickup;
    private float destroyTimer = 3.0f;


    private void Awake()
    {
        pickup = GetComponent<Pickup>();
    }


    private void OnDestroy()
    {
        UnsubscribeFromEvents();
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SubscribeToEvents();
            pickup.GetPickedUp();
            Destroy(gameObject, destroyTimer);
        }
    }
}
