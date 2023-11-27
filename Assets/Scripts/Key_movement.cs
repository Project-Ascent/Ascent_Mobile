using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_movement : MonoBehaviour
{
    private Animator animator;
    public GameObject player;

    public float speed;
    private float dy, dx;

    private bool player_catch = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            Debug.Log("player catching");
            player.GetComponent<PlayerKey>().hasKey = true;
            player_catch = true;
            animator.enabled = false;
        }
    }

    void FixedUpdate()
    {
        if(player.GetComponent<PlayerMove>().doorOpening)
        {
            transform.localScale -= new Vector3(1.0f * Time.deltaTime, 1.0f * Time.deltaTime, 1.0f * Time.deltaTime);
            if(transform.localScale.x <= 0.1f)
            {
                Destroy(gameObject);
            }
        }

        if (player_catch)
        {
            Debug.Log("Player: " + player.transform.position);
            transform.position = Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);
            Debug.Log("dir: " + transform.position);
        }
    }
}

