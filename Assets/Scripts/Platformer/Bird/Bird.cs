using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Transform hookTransform;
    public bool IsAttached { get; set; } = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHook"))
        {
            hookTransform = other.gameObject.transform;
            IsAttached = true;
            StartCoroutine(AttachBird());
        }
    }

    IEnumerator AttachBird()
    {
        while (IsAttached)
        {
            hookTransform.position = transform.position;
            yield return null;
        }
        yield break;
    }
}
