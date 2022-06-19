using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Variables exposed to Editor
    [Header("Movement Settings")]
    [SerializeField] [Tooltip("Speed in m/s")] [Range(1f,10f)] private float speed;
    [SerializeField] [Tooltip("How quickly the character rotates when receiving a new movement direction")] private float rotationSpeed;

    // Private variables
    private Rigidbody rigidBody;
    private Animator animator;
    private Vector2 movementVector2D;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    // Function "OnMove" is invoked by the "Move" Action defined in InputActions
    private void OnMove(InputValue inputValue)
    {
        movementVector2D = inputValue.Get<Vector2>(); // Retrieve movement vector from input device
    }


    private void MovePlayer()
    {
        if (movementVector2D != Vector2.zero)
        {
            animator.SetBool("IsMoving", true);

            // Find movement direction and rotate player towards that direction
            Vector3 movementDirection = new Vector3(movementVector2D.x, 0, movementVector2D.y);
            movementDirection.Normalize();
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

            // Move player
            Vector3 movementDelta = movementDirection * speed * Time.deltaTime; // Multiply by deltaTime so that speed is applied in m/s and not meters per frame
            rigidBody.MovePosition(transform.position + movementDelta);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }


    // Frame-rate independent update call
    void FixedUpdate()
    {
        if (GameManager.Instance.GameState == GameManager.GameStates.Play)
        {
            MovePlayer();
        }
        else
        {
            animator.SetBool("IsMoving", false); // Makes sure player animation resets to idle upon leaving the "Play" state
        }
    }
}
