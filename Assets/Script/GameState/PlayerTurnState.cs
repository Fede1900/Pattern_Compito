using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : State
{
    private PlayerController _playerController;

    public PlayerTurnState(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public override void OnEnter()
    {
        _playerController.StateMachine.SetState(CubeStateType.Active);
    }
}
