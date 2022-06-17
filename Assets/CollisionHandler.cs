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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pickup detected player collision! Score: " + pickup.GetPickedUp());
            Destroy(gameObject, destroyTimer);
        }
    }
}
