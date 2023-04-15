using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInactiveState : State
{
    private Enemy _enemy;

    public EnemyInactiveState(Enemy enemy)
    {
        _enemy = enemy;
    }
}
