using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovementUpDown : MonoBehaviour
{
    public bool isAttached = false;


    // 움직인 거리를 나타내는 변수
    float distanceMoved = 0f;
    // 목표로 하는 이동 거리
    float targetDistance = 8f;
    void OnTriggerEnter2D(Collider2D other)
    {
        isAttached = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.y == -1)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
            distanceMoved += Time.deltaTime;

            if (distanceMoved >= targetDistance)
            {
                // 회전을 초기화하고 거리를 리셋
                transform.localEulerAngles = new Vector3(0, 0, 0);
                distanceMoved = 0f;
            }
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            distanceMoved += Time.deltaTime;
            // 움직인 거리가 목표 거리에 도달하면
            if (distanceMoved >= targetDistance)
            {
                // 회전을 초기화하고 거리를 리셋
                transform.localEulerAngles = new Vector3(0, -180, 0);
                distanceMoved = 0f;
            }
        }
    }
}
