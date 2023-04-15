using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public StateMachine<CubeStateType> StateMachine { get; } = new();

    public LayerMask mask;

    private void Awake()
    {
        //GameManager.Instance.player = this;

        StateMachine.RegisterState(CubeStateType.Active, new PlayerActiveState(this));
        StateMachine.RegisterState(CubeStateType.Inactive, new PlayerInactiveState(this));

        StateMachine.SetState(CubeStateType.Inactive);

    }

    // Start is called before the first frame update
    void Start()
    {       
        

       
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.Update();

        

    }


}
