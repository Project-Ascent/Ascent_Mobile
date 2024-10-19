using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovementUpDown : MonoBehaviour
{
    public bool isAttached = false;


    // ������ �Ÿ��� ��Ÿ���� ����
    float distanceMoved = 0f;
    // ��ǥ�� �ϴ� �̵� �Ÿ�
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
                // ȸ���� �ʱ�ȭ�ϰ� �Ÿ��� ����
                transform.localEulerAngles = new Vector3(0, 0, 0);
                distanceMoved = 0f;
            }
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            distanceMoved += Time.deltaTime;
            // ������ �Ÿ��� ��ǥ �Ÿ��� �����ϸ�
            if (distanceMoved >= targetDistance)
            {
                // ȸ���� �ʱ�ȭ�ϰ� �Ÿ��� ����
                transform.localEulerAngles = new Vector3(0, -180, 0);
                distanceMoved = 0f;
            }
        }
    }
}
