using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossMove : MonoBehaviour
{
    private Animator animator;
    private Vector3 dir;
    System.Random rand;
    
    public bool bossHit = false;

    public GameObject Target;
    private float targetY;
    private float dy, dx;

    public float waitingTime;
    public float repeatTime;

    public GameObject rock;
    public GameObject musicNote;
    public GameObject fallingRock;

    public GameObject throwRockPoint;
    public GameObject musicNotePoint;
    public GameObject fallingRockPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        animator = GetComponent<Animator>();
        InvokeRepeating("bossAct", waitingTime, repeatTime);
    }

    void bossAct()
    {
        dir = Target.transform.position - transform.position;
        dir.x = dir.x / System.Math.Abs(dir.x);
        dir.y = dir.y / System.Math.Abs(dir.y);

        transform.localScale = new Vector3(0.8f * dir.x, 0.8f, 0.8f);

        dy = 0; dx = 0;
        double op = rand.NextDouble();
        //op = 0.9f;
        if (op < 0.2f)
        {
            animator.Play("boss_walk");
            dy = 0; dx = dir.x * 3;
        }
        else if (op < 0.4f)
        {
            animator.Play("boss_jump");
            Invoke("jumpTiming", 0.6f);
        }
        else if (op < 0.6f)
        {
            animator.Play("boss_falling_rock");
            Invoke("fallingRockTiming", 1);
        }
        else if (op < 0.8f)
        {
            animator.Play("boss_throw_rock");
            Invoke("throwTiming", 0.6f);
        }
        else
        {
            if (targetY > 8)
            {
                animator.Play("boss_music_note");
                Invoke("musicNoteTiming", 1);
            }
            else
            {
                animator.Play("boss_body_slam");
                Invoke("bodySlamTiming", 0.6f);
            }
        }
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        if(bossHit)
        {
            if(GetComponent<boss_life>().amount == 0)
            {
                CancelInvoke("bossAct");
                Invoke("dieTiming", 0.5f);
            }
            else
            {
                CancelInvoke("bossAct");
                Invoke("hitTiming", 0.5f);
                InvokeRepeating("bossAct", waitingTime, repeatTime);
            }
            bossHit = false;
        }
        if (transform.position.x < -8.5 && dx < 0)
        {
            dx = 0;
        }
        else if (transform.position.x > 8.5 && dx > 0)
        {
            dx = 0;
        }
        targetY = Target.transform.position.y;
        
        var cur_animation = animator.GetCurrentAnimatorStateInfo(0);
        if (cur_animation.IsName("boss_walk") ||
            cur_animation.IsName("boss_jump") ||
            cur_animation.IsName("boss_body_slam"))
        {
            transform.Translate(dx * Time.deltaTime, dy * Time.deltaTime, 0);
        }
    }

    void throwTiming()
    {
        GameObject clone = Instantiate(rock);
        clone.transform.position = throwRockPoint.transform.position;
        Destroy(clone, 10);
    }
    void fallingRockTiming()
    {
        GameObject clone1 = Instantiate(fallingRock);
        clone1.transform.position = fallingRockPoint.transform.position;
        Destroy(clone1, 10);
    }
    void musicNoteTiming()
    {
        GameObject clone2 = Instantiate(musicNote);
        clone2.transform.position = musicNotePoint.transform.position;
        Destroy(clone2, 10);
    }
    void jumpTiming()
    {
        dy = 10; dx = dir.x * 3;
        Invoke("downTiming", 0.55f);
    }
    void downTiming()
    {
        dy = -10; dx = dir.x * 3;
        Invoke("stopTiming", 0.55f);
    }
    void stopTiming()
    {
        dy = 0; dx = 0;
    }
    void bodySlamTiming()
    {
        dy = 0; dx = dir.x * 10;
        Invoke("stopTiming", 2);
    }
    void hitTiming()
    {
        dy = 0; dx = 0;
        //animator.Play("boss_damaged");
    }
    void dieTiming()
    {
        dy = 0; dx = 0;
        animator.Play("boss_die");
    }
}
