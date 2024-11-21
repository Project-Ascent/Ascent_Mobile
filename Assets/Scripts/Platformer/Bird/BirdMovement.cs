using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField]
    private bool isMovementDirectionUpDown = true;
    [SerializeField]
    private float maxDistance = 8f; // 최대 이동 거리
    private float movedDistance = 0f; // 움직인 거리
    private float delayAfterChangeDirection = 0.5f;

    void Start()
    {
        if (isMovementDirectionUpDown)
        {
            StartCoroutine(MoveUpDown());
        }
        else
        {
            StartCoroutine(MoveLeftRight());
        }
    }

    IEnumerator MoveUpDown()
    {
        int movementDirection = 1;
        while (true)
        {
            transform.Translate(Vector3.up * movementDirection * Time.deltaTime);
            movedDistance += Time.deltaTime;

            if (maxDistance <= movedDistance)
            {
                if (movementDirection == 1)
                {
                    transform.localEulerAngles = new Vector3(0, -180, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                movementDirection *= -1;
                movedDistance = 0f;
                yield return new WaitForSeconds(delayAfterChangeDirection);
            }
            yield return null;
        }
    }

    IEnumerator MoveLeftRight()
    {
        int movementDirection = 1;
        while (true)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            movedDistance += Time.deltaTime;
            if (maxDistance <= movedDistance)
            {
                if (movementDirection == 1)
                {
                    transform.localEulerAngles = new Vector3(0, -180, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                movementDirection *= -1;
                movedDistance = 0f;
                yield return new WaitForSeconds(delayAfterChangeDirection);
            }
            yield return null;
        }
    }
}
