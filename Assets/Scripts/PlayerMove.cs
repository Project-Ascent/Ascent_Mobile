using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;

    public float moveX = 1;
    public float curY; // Player�� ���� Y��ǥ

    private bool isWalkFirst = true;
    private bool isIdleNow = false;
    private Animator animator;

    GrapplingHook grappling;


    public bool inputLeft = false;
    public bool inputRight = false;

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
        float x = Input.GetAxisRaw("Horizontal") * moveX;

        moveDelta = new Vector3(x, 0, 0);
        // Debug.Log(moveDelta);
        if (isWalkFirst && x != 0 && !grappling.isAttach)
        {
            isWalkFirst = false;
            isIdleNow = false;
            animator.Play("move");
        }

        if (!isIdleNow && x == 0)
        {
            isWalkFirst = true;
            isIdleNow = true;
            animator.Play("idle");
        }

        if (grappling.isAttach)
        {
            isWalkFirst = true;
            isIdleNow = true;
            animator.Play("idle");
        }


        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 1);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 1);
        }
        transform.Translate(moveDelta * Time.deltaTime * 2);
    }

    private void Update()
    {
        if (!inputLeft && !inputRight)
        {
            animator.Play("idle");
        }
        else if (inputLeft)
        {
            animator.Play("move");
            transform.localScale = new Vector3(-2.5f, 2.5f, 1);
            moveDelta = new Vector3(moveX, 0, 0);
            transform.Translate(-moveDelta * Time.deltaTime * 2);
        }
        else if (inputRight)
        {
            animator.Play("move");
            transform.localScale = new Vector3(2.5f, 2.5f, 1);
            moveDelta = new Vector3(moveX, 0, 0);
            transform.Translate(moveDelta * Time.deltaTime * 2);
        }
    }
}
