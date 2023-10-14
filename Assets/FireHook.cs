using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class FireHook : MonoBehaviour
{
    public GameObject hook;
    public Transform pos;
    private float curTime;

    private void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }

    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Instantiate(hook, pos.position, transform.rotation);
        }
    }
}
