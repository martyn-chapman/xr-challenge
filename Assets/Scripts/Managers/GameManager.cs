using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerManager PlayerManager { get; private set; }
    public UI_Manager UI_Manager { get; private set; }


    protected override void Init()
    {
        PlayerManager = GetComponentInChildren<PlayerManager>();
        UI_Manager = GetComponentInChildren<UI_Manager>();
    }
}
