using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunPickup : MonoBehaviour
{

    [SerializeField] int turn = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            PubSub.Instance.SendMessage("StunPickUp", turn);
            Destroy(gameObject);
        }
    }
}
