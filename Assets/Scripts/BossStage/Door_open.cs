using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_open : MonoBehaviour
{
    private bool isOpen = false;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (isOpen) return;

            PlayerKey player = other.GetComponent<PlayerKey>();
            
            if (player.hasKey)
            {
                animator.Play("door_open");
                Debug.Log("play key : " + player.hasKey);
                other.GetComponent<PlayerMove>().wallcollision = false;
                other.GetComponent<PlayerMove>().doorOpening = true;
                isOpen = true;
                
                TutorialManager tm = GameObject.Find("TutorialManager").GetComponent<TutorialManager>();
                tm.tm1TextBoss.SetActive(false);
                tm.tm2TextBoss.SetActive(true);
            }
            else
            {
                other.GetComponent<PlayerMove>().wallcollision = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
