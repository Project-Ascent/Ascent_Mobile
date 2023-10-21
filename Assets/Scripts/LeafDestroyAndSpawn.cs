using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafDestroyAndSpawn : MonoBehaviour
{
    public bool isTouched = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "grapplingHook")
        {
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
