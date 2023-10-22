using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockPoint : MonoBehaviour
{
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Target.transform.position.x,
                                         transform.position.y,
                                         0);
    }
}
