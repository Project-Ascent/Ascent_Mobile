using HookControlState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    private bool isTouched = false;
    private int isTutorial; // 1: Tutorial, 0 : Not

    private DistanceJoint2D grapplingHookJoint2D;
    private SpriteRenderer leafSpriteRenderer;
    private EdgeCollider2D leafEdgeCollider2D;
    private HookController hookController;

    private float destroyDelay = 2f;
    private float respawnDelay = 3f;
    public bool IsAttachedThisLeaf { get; set; } = false;

    private void Awake()
    {
        leafSpriteRenderer = GetComponent<SpriteRenderer>();
        leafEdgeCollider2D = GetComponent<EdgeCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHook"))
        {
            IsAttachedThisLeaf = true;
            grapplingHookJoint2D = other.gameObject.GetComponent<DistanceJoint2D>();
            hookController = other.gameObject.GetComponent<HookController>();
            StartCoroutine(RemoveAndRespawnLeaf());
        }
    }

    IEnumerator RemoveAndRespawnLeaf()
    {
        yield return new WaitForSeconds(destroyDelay);
        if (grapplingHookJoint2D != null && hookController != null)
        {
            if (IsAttachedThisLeaf && hookController.hookStateContext.currentState is HookAttachState)
            {
                grapplingHookJoint2D.enabled = false;
                hookController.IsMouseClicked = true;
            }
            SetLeafActive(false);
            yield return new WaitForSeconds(respawnDelay);
            SetLeafActive(true);
        }
        yield break;
    }

    private void SetLeafActive(bool val)
    {
        if (leafSpriteRenderer != null &&  leafEdgeCollider2D != null)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = val;
            gameObject.GetComponent<EdgeCollider2D>().enabled = val;
        }
    }
}
