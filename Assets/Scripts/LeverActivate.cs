using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool activation = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        if(activation)
        {
            animator.Play("lever_on");
        }
        else
        {
            animator.Play("lever_idle");
        }
    }
}
