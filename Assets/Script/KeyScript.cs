using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] KeyColor keyColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            PubSub.Instance.SendMessage(keyColor.ToString(), true);

            Destroy(gameObject);
        }
    }
}
