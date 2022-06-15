using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Variables exposed to Editor
    [Header("Input Settings")]
    [SerializeField] [Tooltip("Speed in m/s")] [Range(1f,10f)] private float speed = 1f;

    // Private variables
    private Rigidbody rigidBody;
    private Vector2 movementVector2D;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    // Function "OnMove" is invoked by the "Move" Action defined in InputActions
    private void OnMove(InputValue inputValue)
    {
        movementVector2D = inputValue.Get<Vector2>(); // Retrieve movement vector from input device
    }


    private void MovePlayer()
    {
        Vector3 movementDelta = new Vector3(movementVector2D.x, 0, movementVector2D.y) * speed * Time.deltaTime; // Still multiply by deltaTime so that speed is applied accurately in m/s
        rigidBody.MovePosition(transform.position + movementDelta);
    }


    // Frame-rate independent update call
    void FixedUpdate()
    {
        MovePlayer();
    }
}
