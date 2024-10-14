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
    public int isTutorial; // 1 : Tutorial, 0 : Not

    public float hookableAreaWidthPercentage = 0.8f;
    public float hookableAreaHeightPercentage = 0.8f;

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

        // 다수의 터치 입력 처리
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            //Debug.Log("터치 발생!");
            // UI 터치와 화면 터치 구분
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                // 화면 터치일 때
                if (touch.phase == UnityEngine.TouchPhase.Began)
                {
                    // Debug.Log("이 터치는 화면 터치입니다.");

                    // 훅 발사
                    if (!isHookFired)
                    {
                        Vector2 touchPosition = touch.position;
                        FireHook(touchPosition);
                    }
                    else if (isAttach)
                    {
                        ResetHookState();
                    }
                }
            }
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

    void FireHook(Vector2 direction)
    {
        print("훅 발사!");
        hook.position = transform.position;
        mouseDir = Camera.main.ScreenToWorldPoint(direction) - transform.position;
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

    public void ResetHookState()
    {
        isHookFired = false;
        isRangeMax = false;
        isAttach = false;
        if (isTutorial == 1)
        {
            hook.GetComponent<Attached_Tutorial>().joint2D.enabled = false;
            hook.gameObject.SetActive(false);
        }
        else
        {
            hook.GetComponent<Attached>().joint2D.enabled = false;
            hook.gameObject.SetActive(false);
        }
    }
}
