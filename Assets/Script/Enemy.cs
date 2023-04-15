using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public StateMachine<CubeStateType> StateMachine { get; } = new();

    public LayerMask mask;

    


    // Start is called before the first frame update
    void Start()
    {
        StateMachine.RegisterState(CubeStateType.Active, new EnemyActiveState(this));
        StateMachine.RegisterState(CubeStateType.Inactive, new EnemyInactiveState(this));

        StateMachine.SetState(CubeStateType.Inactive);
        GameManager.Instance.AddEnemy(this);

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null && GetComponent<Stunned>() == null)
        {
            Debug.Log("hai perso");

            GameManager.Instance.SetLose();
        }
    }

   
}
