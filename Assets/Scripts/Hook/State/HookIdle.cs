using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine;

namespace HookControlState
{
    public class HookIdleState : MonoBehaviour, HookState
    {
        private HookController hookController;

        public void Action(HookController controller)
        {
            if (!hookController) // null이거나 비활성화 상태인지 확인
            {
                hookController = controller;
            }
        }

        void Update()
        {
            // 여러 터치가 동시에 들어왔을 때의 처리
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                // UI 터치와 화면 터치 구분
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    // 화면 터치일 때
                    if (touch.phase == UnityEngine.TouchPhase.Began)
                    {
                        // HookFire로 상태 변경
                    }
                }
            }
        }

        void RetractHook()
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 1000);

            if (Vector2.Distance(transform.position, hook.position) < 0.1f)
            {
                hook.GetComponent<Attached>().joint2D.enabled = false;
                hook.gameObject.SetActive(false);
            }
        }

        public void ResetHookState()
        {
            if (GameManager.Instance.getIsTutorial())
            {
                hook.GetComponent<Attached_Tutorial>().joint2D.enabled = false;
            }
            else
            {
                hook.GetComponent<Attached>().joint2D.enabled = false;
            }
            hook.gameObject.SetActive(false);
        }
    }
}

