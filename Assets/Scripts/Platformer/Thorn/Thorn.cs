using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    private int damage = 1;
    private float invincibleTime = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !HPManager.Instance.IsInvincible)
        {
            ApplyDamage();
            StartCoroutine(ApplyInvincibility(invincibleTime));
        }
    }

    void ApplyDamage()
    {
        HPManager.Instance.DecreaseHP(damage);
    }

    private IEnumerator ApplyInvincibility(float invincibleTime)
    {
        HPManager.Instance.IsInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        HPManager.Instance.IsInvincible = false;
    }
}
