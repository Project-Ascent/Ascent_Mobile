using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attached : MonoBehaviour
{
    GrapplingHook grappling;
    public DistanceJoint2D joint2D;
    // Start is called before the first frame update
    void Start()
    {
        grappling = GameObject.Find("Player").GetComponent<GrapplingHook>();
        joint2D = GetComponent<DistanceJoint2D>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            joint2D.enabled = true;
            grappling.isRangeMax = true;
            grappling.isAttach = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
