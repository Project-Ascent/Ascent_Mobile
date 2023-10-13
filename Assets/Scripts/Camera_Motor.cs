using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Motor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float deltaY = lookAt.position.y - transform.position.y;

        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(0, delta.y, 0);
    }
}
