using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class Leaf : MonoBehaviour
{

    private float disappearTime = 2f;
    private float appearTime = 3f;
    private bool isCollision = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHook"))
        {
            isCollision = true;
            StartCoroutine(DisappearAndAppearLeaf());
        }
    }

    private void SetLeafActive(bool val)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = val;
        gameObject.GetComponent<EdgeCollider2D>().enabled = val;
    }

    private IEnumerator DisappearAndAppearLeaf()
    {
        yield return new WaitForSeconds(disappearTime);
        SetLeafActive(false);

        yield return new WaitForSeconds(appearTime);
        SetLeafActive(true);
    }

    public bool GetIsCollision() {  return isCollision; }
}
