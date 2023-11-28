using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;

    public float moveX = 1;
    public float curY; // PlayerÀÇ ÇöÀç YÁÂÇ¥

    private bool isWalkFirst = true;
    private bool isIdleNow = false;
    private Animator animator;

    public bool wallcollision;
    public bool doorOpening = false;

    public bool inputLeft = false;
    public bool inputRight = false;

    GrapplingHook grappling;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        grappling = GetComponent<GrapplingHook>();

        UIButtonManager ui = GameObject.FindGameObjectWithTag("Managers").GetComponent<UIButtonManager>();
        ui.init();
    }

    private void FixedUpdate()
    {
        // Debug.Log(inputLeft + " -  " + inputRight);
        if (!inputLeft && !inputRight)
        {
            animator.Play("idle");
        }
        else if (inputLeft)
        {
            animator.Play("move");
            transform.localScale = new Vector3(-2.5f, 2.5f, 1);
            if (wallcollision)
            {
                moveDelta = new Vector3(0, 0, 0);
            }
            else
            {
                moveDelta = new Vector3(moveX, 0, 0);
            }
            transform.Translate(-moveDelta * Time.deltaTime * 2);
        }
        else if (inputRight)
        {
            wallcollision = false;
            animator.Play("move");
            transform.localScale = new Vector3(2.5f, 2.5f, 1);
            moveDelta = new Vector3(moveX, 0, 0);
            transform.Translate(moveDelta * Time.deltaTime * 2);
        }
    }
}
