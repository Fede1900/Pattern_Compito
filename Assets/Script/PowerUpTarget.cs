using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTarget : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        PubSub.Instance.RegisteredFunction("StunPickUp", OnStunPickUp);
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnStunPickUp(object content)
    {
        if (content is not int)
        {
            return;
        }

        Stunned stun = gameObject.GetComponent<Stunned>();

        if (stun == null)
        {
            stun = gameObject.AddComponent<Stunned>();
            stun.SetTurn((int)content);

            
        }
        else
        {
            stun.IncreasedTime((int)content);
        }

    }
}
