using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossMove : MonoBehaviour
{
    private Animator animator;
    private Vector3 dir;
    System.Random rand;

    public GameObject Target;
    private float targetY;
    private float motionTime;

    public float waitingTime;
    public float repeatTime;

    public GameObject rock;
    public GameObject musicNote;
    public GameObject throwRockPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        animator = GetComponent<Animator>();
        InvokeRepeating("bossAct", waitingTime, repeatTime);
    }

    void bossAct()
    {
        motionTime = 0;
        double op = rand.NextDouble();
        //op = 0.3f;
        if (op < 0.2f)
        {
            animator.Play("boss_walk");
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
        motionTime += 1;
        targetY = Target.transform.position.y;
        dir = Target.transform.position - transform.position;
        dir.x = dir.x / System.Math.Abs(dir.x);
        dir.y = dir.y / System.Math.Abs(dir.y);
        
        if (dir.x > 0)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else if (dir.x < 0)
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        }

        var cur_animation = animator.GetCurrentAnimatorStateInfo(0);
        if (cur_animation.IsName("boss_walk"))
        {
            transform.Translate(dir.x * Time.deltaTime * 2, 0, 0);
        }
        else if (cur_animation.IsName("boss_jump"))
        {   
            if(transform.position.y < -0.5)
            {
                dir.y = 0.1f;
            }
            else if (motionTime < 54 || motionTime >257)
            {
                dir.x = 0;
                dir.y = 0;
            }
            else if(motionTime < 153)
            {
                dir.y = 1;
            }
            else if(motionTime >= 153 || transform.position.y > 6)
            {
                dir.y = -1;
            }

            transform.Translate(dir.x * Time.deltaTime * 2,
                dir.y * Time.deltaTime * 10,
                0);
        }
        else if (cur_animation.IsName("boss_body_slam"))
        {
            if(motionTime < 96)
            {
                dir.x = 0;
            }
            transform.Translate(dir.x * Time.deltaTime * 10, 0, 0);
        }
    }

    void idleAnimation()
    {
        animator.Play("boss_stand");
    }
    
}
