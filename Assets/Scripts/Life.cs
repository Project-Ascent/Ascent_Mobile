using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float amount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (amount == 2)
        {   
            Destroy(GameObject.Find("Life_3"));
        }else if (amount == 1)
        {
            Destroy(GameObject.Find("Life_2"));
        }else if (amount <= 0)
        {
            Destroy(GameObject.Find("Life_1"));
        }
    }
}
