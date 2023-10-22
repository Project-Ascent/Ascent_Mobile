using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRockMove : MonoBehaviour
{
    private Vector3 dir;
    public GameObject Target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        dir = Target.transform.position - transform.position;
        dir = dir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed);
    }
}
