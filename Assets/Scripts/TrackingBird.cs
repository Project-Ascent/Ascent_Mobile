using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBird : MonoBehaviour
{

    Vector2 birdPosition;
    Vector2 hookPosition;
    Vector2 playerPosition;
    // 새의 좌표에서 훅이 걸린 좌표까지의 거리
    Vector2 distance;

    public bool isAttachedOnBird = false;

    GrapplingHook grappling;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "grapplingHook")
        {
            hookPosition = grappling.hook.position;
            distance = birdPosition - hookPosition;
            isAttachedOnBird = true;
        }
    }


    void Start()
    {
        grappling = GameObject.Find("Player").GetComponent<GrapplingHook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttachedOnBird && grappling.isAttach)
        {
            birdPosition = transform.position;
            hookPosition = birdPosition;
            grappling.hook.position = hookPosition;
        }

        if (!grappling.isAttach)
        {
            isAttachedOnBird = false;
        }

    }
}
