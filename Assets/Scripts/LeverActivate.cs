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

    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.Play("lever_on");
        TargetP.transform.position = new Vector3(-6.71f, -3.29f, 0);
        TargetB.GetComponent<Animator>().Play("boss_stand");
        TargetB.transform.position = new Vector3(6.53f, -0.5f, 0);

        Invoke("afterFalling", fallDelay);
    }
    void afterFalling()
    {
        animator.Play("lever_idle");

        GameObject clone = Instantiate(fallingRock);
        clone.transform.position = new Vector3(TargetB.transform.position.x,
                                               TargetB.transform.position.y + 10,
                                               0);
        Destroy(clone, 1);

        Invoke("afterDamage", bossDelay);
    }

    void afterDamage()
    {
        TargetB.GetComponent<BossMove>().bossHit = true;
        TargetB.GetComponent<Animator>().Play("boss_damaged");
        TargetB.GetComponent<boss_life>().amount -= 1;
    }
}
