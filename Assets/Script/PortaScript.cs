using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript : MonoBehaviour
{
    [SerializeField] KeyColor KeyColor;

    private void Start()
    {
        PubSub.Instance.RegisteredFunction(KeyColor.ToString(), OnKeyCollected);
    }

    private void OnKeyCollected(object content)
    {
        gameObject.SetActive(false);
    }
}
