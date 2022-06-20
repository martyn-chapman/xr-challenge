using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    private Animator animator;
    private Text3D text3D;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        text3D = GetComponent<Text3D>();
    }

    public void HitResponse()
    {
        animator.SetTrigger("HitTrigger");

        text3D.CreateText("Ow!", 1.0f);
        Bark();
    }


    private void Bark()
    {
        GameManager.Instance.AudioManager.Play("Bark");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.PlayerManager.GetItemsCounter() >= GameManager.Instance.WinCondition)
            {
                GameManager.Instance.UpdateGameState(GameManager.GameStates.Win);
                text3D.CreateText("Congratulations!");
                Bark();
            }
            else
            {
                text3D.CreateText("Come back to me once you have all the stars!");
                Bark();
            }
        }
    }
}
