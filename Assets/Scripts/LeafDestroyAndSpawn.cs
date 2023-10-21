using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafDestroyAndSpawn : MonoBehaviour
{
    public bool isTouched = false;
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

        // �Ÿ� �Ӱ谪 ����
        float distanceThreshold = 0f;
        // grappling.hook.position�� hookPosition ������ �Ÿ� ���
        float distance = Vector2.Distance(hookPosition, grappling.hook.position);
        if (distance == distanceThreshold)
        {
            grappling.hook.GetComponent<Attached>().joint2D.enabled = false;
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
