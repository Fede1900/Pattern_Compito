using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesoro : MonoBehaviour
{
    [SerializeField] int punteggio = 200;
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
            GameManager.Instance.Punteggio += punteggio;

            Destroy(gameObject);
        }
    }
}
