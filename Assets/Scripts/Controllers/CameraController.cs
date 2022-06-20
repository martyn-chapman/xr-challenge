using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 offset;
    private Vector3 playerPosition;

    private void Start()
    {
        playerPosition = GameManager.Instance.PlayerManager.GetPlayerPosition();
        offset = new Vector2(transform.position.y - playerPosition.y, transform.position.z - playerPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameManager.Instance.PlayerManager.GetPlayerPosition();
        transform.position = new Vector3(playerPosition.x, playerPosition.y + offset.x, playerPosition.z + offset.y);
    }
}
