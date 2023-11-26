using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
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

    public float hookableAreaWidthPercentage = 0.8f;
    public float hookableAreaHeightPercentage = 0.8f;
    private float hookableAreaWidth;
    private float hookableAreaHeight;

    private bool isMoveButtonPressed; // ������ ����

    void Start()
    {
        InitializeLineRenderer();
        InitializeHook();
    }

    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);

        // �̵� ��ư�� ���ʷ� ������ ��
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("isMoveButtonPressed�� True�� �ٲ�");
                isMoveButtonPressed = true;
            }

            // ���� �߻���� ���� ���¿����� ���� �߻�
            if (!isHookFired && isMoveButtonPressed)
            {
                Debug.Log("�� �߻�");
                FireHook();
            }
        }

        // �̵� ��ư�� ������ ��
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Ended)
        {
            isMoveButtonPressed = false;
        }


        // �� �߻� ���� ���۵�
        if (isHookFired && !isRangeMax)
        {
            MoveHook();
            CheckMaxRange();
        }
        else if (isHookFired && isRangeMax && !isAttach)
        {
            RetractHook();
        }

        else if (isAttach)
        {
            // ���� �̹� �پ��ִ� ���¿��� �̵� ��ư�� ���� ���� ���� ȸ������ ����
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    Debug.Log("���� �پ��ִ� ����, �̵� ��ư�� ������ ���� ȸ���Ǹ� �ȵ�");
                    ResetHookState();
                }
            }
        }
    }

    void InitializeLineRenderer()
    {
        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.useWorldSpace = true;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
    }

    void InitializeHook()
    {
        hook.gameObject.SetActive(false);
    }

    void FireHook()
    {
        hook.position = transform.position;
        mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        isHookFired = true;
        isRangeMax = false;
        isAttach = false;
        hook.gameObject.SetActive(true);
    }

    void MoveHook()
    {
        hook.Translate(mouseDir.normalized * Time.deltaTime * launchSpeed);

        if (Vector2.Distance(transform.position, hook.position) > 10) // ���� �ִ� ��Ÿ�
        {
            isRangeMax = true;
        }
    }

    void CheckMaxRange()
    {
        if (Vector2.Distance(transform.position, hook.position) > 10) // ���� �ִ� ��Ÿ�
        {
            isRangeMax = true;
        }
    }

    void RetractHook()
    {
        hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 1000);

        if (Vector2.Distance(transform.position, hook.position) < 0.1f)
        {
            ResetHookState();
            isMoveButtonPressed = false; // ��ư�� ���� �� ������ false�� ����
        }
    }

    void ResetHookState()
    {
        isHookFired = false;
        isRangeMax = false;
        isAttach = false;
        hook.GetComponent<Attached>().joint2D.enabled = false;
        hook.gameObject.SetActive(false);
    }
}
