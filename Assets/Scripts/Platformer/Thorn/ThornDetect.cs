using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ThornDetect : MonoBehaviour
{
    public static ThornDetect td;
    public float damage;
    private bool isDamaged = false;
    private float invincibleTime = 3f;
    private Life life;
    AudioSource damagedSound;

    void Start()
    {
        // 사운드매니저가 필요할거 같은데 따로
        damagedSound = GameObject.Find("Thornsound").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            life = other.gameObject.GetComponent<Life>();
            if (life != null && !life.IsDamaged)
            {
                StartCoroutine(ApplyDamage());
                if (damagedSound != null)
                {
                    damagedSound.Play();
                }
            }
        }
    }

    IEnumerator ApplyDamage()
    {
        life.amount -= damage;
        life.IsDamaged = true;
        yield return new WaitForSeconds(invincibleTime);
        life.IsDamaged = false;
    }

    void ChangeDamaged()
    {
        if (!life.IsDamaged)
        {
            life.amount -= damage;
            life.IsDamaged = true;
        }
    }
    void ResetDamageState()
    {
        life.IsDamaged = false;
    }
    // Start is called before the first frame update
}
