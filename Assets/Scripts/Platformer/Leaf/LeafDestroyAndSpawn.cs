using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafDestroyAndSpawn : MonoBehaviour
{
    public bool isTouched = false;
    public int isTutorial; // 1: Tutorial, 0 : Not
    Vector2 leafPosition;
    Vector2 hookPosition;

    GrapplingHook grappling;
    public DistanceJoint2D joint2D;
    private int fireCount = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "grapplingHook")
        {
            isTouched = true;
            hookPosition = grappling.hook.position;
            Invoke("DestroyLeafAndSpawn", 2f);
        }
    }

    void DestroyLeafAndSpawn()
    {
        leafPosition = transform.position;

        // 거리 임계값 설정
        float distanceThreshold = 0f;
        // grappling.hook.position과 hookPosition 사이의 거리 계산
        float distance = Vector2.Distance(hookPosition, grappling.hook.position);
        if (distance == distanceThreshold)
        {
            if (isTutorial == 1)
            {
                grappling.hook.GetComponent<Attached_Tutorial>().joint2D.enabled = false;
            }
            else
            {
                grappling.hook.GetComponent<Attached>().joint2D.enabled = false;
            }
            grappling.isRangeMax = true;
            grappling.isAttach = false;
        }
        Destroy(gameObject);
        Invoke("SpawnNewLeaf", 3f);
    }

    void SpawnNewLeaf()
    {
        Instantiate(gameObject, leafPosition, Quaternion.identity);
    }


    void Start()
    {
        grappling = GameObject.Find("Player").GetComponent<GrapplingHook>();
        joint2D = GetComponent<DistanceJoint2D>();
    }
    void Update()
    {
        
    }
}
