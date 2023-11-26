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

    private bool isMoveButtonPressed; // 수정된 변수

    void Start()
    {
        InitializeLineRenderer();
        InitializeHook();
    }

    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);

        // 이동 버튼을 최초로 눌렀을 때
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("isMoveButtonPressed가 True로 바뀜");
                isMoveButtonPressed = true;
            }

            // 훅이 발사되지 않은 상태에서만 훅을 발사
            if (!isHookFired && isMoveButtonPressed)
            {
                Debug.Log("훅 발사");
                FireHook();
            }
        }

        // 이동 버튼을 떼었을 때
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Ended)
        {
            isMoveButtonPressed = false;
        }


        // 훅 발사 후의 동작들
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
            // 훅이 이미 붙어있는 상태에서 이동 버튼을 누를 때는 훅을 회수하지 않음
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    Debug.Log("현재 붙어있는 상태, 이동 버튼을 눌러도 훅이 회수되면 안돼");
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

        if (Vector2.Distance(transform.position, hook.position) > 10) // 훅의 최대 사거리
        {
            isRangeMax = true;
        }
    }

    void CheckMaxRange()
    {
        if (Vector2.Distance(transform.position, hook.position) > 10) // 훅의 최대 사거리
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
            isMoveButtonPressed = false; // 버튼을 떼면 이 변수를 false로 설정
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
