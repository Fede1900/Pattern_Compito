using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunned : MonoBehaviour
{
    [SerializeField] int StunnedTime;

    [SerializeField]Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnPassed()
    {
        StunnedTime--;

        if (StunnedTime <= 0)
        {
            if (animator != null)
            {
                animator.SetBool("Stunned", false);
            }
            Destroy(this);
        }
    }

    public void SetTurn(int value)
    {
        animator = GetComponent<Animator>();
        StunnedTime = value;
        if (animator != null)
        {
            animator.SetBool("Stunned", true);
        }
        
    }

    public void IncreasedTime(int value)
    {
        StunnedTime += value;
    }
}
