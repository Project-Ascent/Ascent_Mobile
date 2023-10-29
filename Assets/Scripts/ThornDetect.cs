using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornDetect : MonoBehaviour
{
    public static ThornDetect td;
    public float damage;
    public bool isDamaged = false;
    public Life life;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="Player"&&!ItemSelected.IS.checkDamaged)
        {
            life = other.gameObject.GetComponent<Life>();

            if (life != null)
            {
                isDamaged = true;
                
                Invoke("ChangeDamged", 0.2f);
                
                
            }
        }
       
    }

    void ChangeDamged()
    {
        if (isDamaged)
            life.amount -= damage;
        isDamaged = false;
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
