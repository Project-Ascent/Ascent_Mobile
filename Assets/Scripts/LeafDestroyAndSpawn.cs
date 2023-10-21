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
            isTouched = true;

            Invoke("DestroyLeaf", 2f);
        }
    }

    void DestroyLeaf()
    {

    }


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
