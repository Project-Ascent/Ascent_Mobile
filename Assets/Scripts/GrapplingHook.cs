using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine.InputSystem;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;
    Vector2 mouseDir;

    public float launchSpeed;
    public bool isHookFired;
    public bool isRangeMax;
    public bool isAttach;
    void Start()
    {
        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        line.useWorldSpace = true;
        hook.gameObject.SetActive(false);
    }

    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);

        if (Input.GetMouseButtonDown(0) && !isHookFired)
        {
            hook.position = transform.position;
            mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            isHookFired = true;
            isRangeMax = false;
            isAttach = false;
            hook.gameObject.SetActive(true);
        }
        if (isHookFired && !isRangeMax)
        {
            hook.Translate(mouseDir.normalized * Time.deltaTime * launchSpeed);

            if (Vector2.Distance(transform.position, hook.position) > 7)
            {
                isRangeMax = true;
            }
        }
        else if (isHookFired && isRangeMax && !isAttach)
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 1000);
            if (Vector2.Distance(transform.position, hook.position) < 0.1f)
            {
                isHookFired = false;
                isRangeMax = false;
                isAttach = false;
                hook.gameObject.SetActive(false);
            }
        }
        else if (isAttach)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                isHookFired = false;
                isRangeMax = false;
                isAttach = false;
                hook.GetComponent<Attached>().joint2D.enabled = false;
                hook.gameObject.SetActive(false);
            }
        }
    }
}
