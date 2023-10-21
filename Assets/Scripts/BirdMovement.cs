using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public bool isAttached = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        isAttached = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.rotation.y == -1)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            
            if (transform.position.x >= Camera.main.transform.position.x + Camera.main.orthographicSize)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            if (transform.position.x <= Camera.main.transform.position.x - Camera.main.orthographicSize)
            {
                transform.localEulerAngles = new Vector3(0, -180, 0);
            }
        }
       
        
    }
    
}
