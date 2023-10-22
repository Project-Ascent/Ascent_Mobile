using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossMove : MonoBehaviour
{
    private Animator animator;
    private Vector3 dir;
    private Vector3 moveDelta;
    System.Random rand;
    
    public GameObject Target;
    public float waitingTime;
    public float repeatTime;

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        animator = GetComponent<Animator>();
        InvokeRepeating("bossAct", waitingTime, repeatTime);
    }

    void bossAct()
    {
        double op = rand.NextDouble();
        float targetY = Target.transform.position.y;
        if (op < 0.2f)
        {
            animator.Play("boss_walk");
            //moveDelta = new Vector3(dir.x, 0, 0);
            //transform.Translate(moveDelta * Time.deltaTime * 2);
        }
        else if (op < 0.4f)
        {
            animator.Play("boss_jump");
        }
        else if (op < 0.6f)
        {
            animator.Play("boss_falling_rock");
        }
        else if (op < 0.8f)
        {
            animator.Play("boss_throw_rock");
        }
        else
        {
            if (targetY > 8)
            {
                animator.Play("boss_music_note");
            }
            else
            {
                animator.Play("boss_body_slam");
            }
        }
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        dir = Target.transform.position - transform.position;
        dir.x = dir.x / System.Math.Abs(dir.x);
        if (dir.x > 0)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else if (dir.x < 0)
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        }
    }
    
}
