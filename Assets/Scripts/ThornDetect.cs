using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornDetect : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="Player")
        {
            Life life = other.gameObject.GetComponent<Life>();

            if (life != null)
            {
                life.amount -= damage;
                
            }
        }
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
