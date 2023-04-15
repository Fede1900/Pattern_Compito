using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInactiveState : State
{
    private PlayerController _playerController;

    public PlayerInactiveState(PlayerController playerController)
    {
        _playerController = playerController;
    }
}
