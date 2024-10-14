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
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;
            }
        }

        void Update()
        {
            // ���� ��ġ�� ���ÿ� ������ ���� ó��
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                // UI ��ġ�� ȭ�� ��ġ ����
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    // ȭ�� ��ġ�� ��
                    if (touch.phase == UnityEngine.TouchPhase.Began)
                    {
                        // HookFire�� ���� ����
                    }
                }
            }
        }

        void RetractHook()
        {
            hookController.hook.position = Vector2.MoveTowards(hookController.hook.position, transform.position, Time.deltaTime * 1000);

            if (Vector2.Distance(transform.position, hookController.hook.position) < 0.1f)
            {
                hookController.hook.GetComponent<Attached>().joint2D.enabled = false;
                hookController.hook.gameObject.SetActive(false);
            }
        }

        public void ResetHookState()
        {
            if (GameManager.Instance.GetIsTutorial())
            {
                hookController.hook.GetComponent<Attached_Tutorial>().joint2D.enabled = false;
            }
            else
            {
                hookController.hook.GetComponent<Attached>().joint2D.enabled = false;
            }
            hookController.hook.gameObject.SetActive(false);
        }
    }
}

