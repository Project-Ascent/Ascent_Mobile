using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ThornDetect : MonoBehaviour
{
    public static ThornDetect td;
    public float damage;
    public bool isDamaged = false;
    public Life life;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="Player")
        {
            Scene scene = SceneManager.GetActiveScene();
            life = other.gameObject.GetComponent<Life>();

            if (life != null && !life.isDamaged)
            {
                if (scene.name == "TutorialScene")
                {
                    Invoke("ChangeDamaged", 0.1f);
                }
                else
                {
                    Invoke("ChangeDamaged", 0.1f);
                    Invoke("ResetDamageState", 3f);
                }
            }
        }
       
    }

    void ChangeDamaged()
    {
        if (!life.isDamaged)
        {
            life.amount -= damage;
            life.isDamaged = true;
        }
    }
    void ResetDamageState()
    {
        life.isDamaged = false;
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
