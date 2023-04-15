using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActiveState : State
{
    private PlayerController _playerController;

    Vector3 startPosition;
    Vector3 endPosition;

    bool inputDone;
    float waitingTime;
    float Timer = 0.1f;  //timer per permettere al giocatore di inbattersi volontariamente su un nemico

    public PlayerActiveState(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        GetPlayerMoveInfo();
    }

    public override void OnExit()
    {
        GameManager.Instance.StateMachine.SetState(GameStateType.EnemyTurn);
    }


    private void GetPlayerMoveInfo()
    {
        if (!inputDone)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                PlayerMove(Vector3.up);
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                PlayerMove(Vector3.down);
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                PlayerMove(Vector3.left);
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                PlayerMove(Vector3.right);
            }
        }
        


        if (inputDone && waitingTime > 0)
        {
            waitingTime -= Time.deltaTime;

            if (waitingTime <= 0)
            {
                inputDone = false;

                _playerController.StateMachine.SetState(CubeStateType.Inactive);
            }
        }
    }

    public void PlayerMove(Vector3 direction)
    {
        startPosition = _playerController.transform.position;

        endPosition = startPosition + direction;

        if (Physics2D.Raycast(startPosition, direction, 1, _playerController.mask))
        {
            return;
        }


        _playerController.transform.Translate(direction);

        inputDone = true;

        waitingTime = Timer;

        
    }



}
