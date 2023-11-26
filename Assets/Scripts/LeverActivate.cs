using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivate : MonoBehaviour
{
    private Animator animator;
    public float fallDelay;
    public float bossDelay;
    public GameObject fallingRock;
    public GameObject TargetP;
    public GameObject TargetB;
    public float speed;

    private bool lever_activate = false;

    private Vector3 dir;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (lever_activate) return;

        lever_activate = true;
        animator.Play("lever_on");
        Invoke("MovePlayer", 1.5f);
    }
    void MovePlayer()
    {
        TargetP.transform.position = new Vector3(-6.71f, -3.29f, 0);
        TargetB.GetComponent<Animator>().Play("boss_stand");
        TargetB.transform.position = new Vector3(6.53f, -0.5f, 0);
        TargetB.transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);

        Invoke("afterFalling", fallDelay);
    }

    void afterFalling()
    {
        animator.Play("lever_idle");

        GameObject clone = Instantiate(fallingRock);
        clone.transform.position = new Vector3(TargetB.transform.position.x,
                                               TargetB.transform.position.y + 10,
                                               0);
        Destroy(clone, 0.7f);

        Invoke("afterDamage", bossDelay);
    }

    void afterDamage()
    {
        TargetB.GetComponent<BossMove>().bossHit = true;
        TargetB.GetComponent<Animator>().Play("boss_damaged");
        TargetB.GetComponent<boss_life>().amount -= 1;
    }
}
