using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : State
{
    private List<Enemy> _enemies;

    

    public EnemyTurnState(List<Enemy> enemies)
    {
        _enemies = enemies;
    }

    public override void OnEnter()
    {

        for (int i = 0; i < _enemies.Count; i++)
        {
            _enemies[i].StateMachine.SetState(CubeStateType.Active);
        }

        
    }

    public override void OnUpdate()
    {
        GameManager.Instance.StateMachine.SetState(GameStateType.PlayerTurn);
    }
}
