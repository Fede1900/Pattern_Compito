using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActiveState : State
{
    private Enemy _enemy;

    private List<Vector3> direzioniPossibili=new List<Vector3>();

    Vector3 startPosition;

    

    public EnemyActiveState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public override void OnEnter()
    {
        direzioniPossibili.Clear();

        if (_enemy.gameObject.GetComponent<Stunned>() != null)
        {
            _enemy.gameObject.GetComponent<Stunned>().TurnPassed();

            _enemy.StateMachine.SetState(CubeStateType.Inactive);
            return;

        }

        PathCreation();

        if (direzioniPossibili.Count == 0)
        {
            Debug.Log("nessuna mossa disponibile");

            _enemy.StateMachine.SetState(CubeStateType.Inactive);

            return;
        }

        int scelta = Random.Range(0, direzioniPossibili.Count);

        Debug.Log(direzioniPossibili.Count);

        Vector3 direzioneScelta = direzioniPossibili[scelta];

        _enemy.transform.Translate(direzioneScelta);



        _enemy.StateMachine.SetState(CubeStateType.Inactive);
    }

    

    private void PathCreation()
    {
        startPosition = _enemy.transform.position;

        if (!Physics2D.Raycast(startPosition, Vector3.up, 1, _enemy.mask))
        {
            direzioniPossibili.Add(Vector3.up);
            
        }

        if (!Physics2D.Raycast(startPosition, Vector3.down, 1, _enemy.mask))
        {
            direzioniPossibili.Add(Vector3.down);
        }

        if (!Physics2D.Raycast(startPosition, Vector3.left, 1, _enemy.mask))
        {
            direzioniPossibili.Add(Vector3.left);
        }

        if (!Physics2D.Raycast(startPosition, Vector3.right, 1, _enemy.mask))
        {
            direzioniPossibili.Add(Vector3.right);
        }
    }
} 
