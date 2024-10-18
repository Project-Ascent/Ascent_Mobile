using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;


    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void PlayIdleAnimation()
    {
        animator.SetBool("isWalking", false);
    }

    public void PlayWalkAnimation()
    {
        animator.SetBool("isWalking", true);
    }
}
