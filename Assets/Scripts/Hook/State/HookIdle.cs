using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine;

namespace HookControlState
{
    public class HookIdleState : HookState
    {
        private HookController hookController;

        public void Handle(HookController controller)
        {
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;
            }
            RetractHook();
        }

        void RetractHook()
        {
            hookController.hookPosition = Vector2.MoveTowards(hookController.hookPosition, hookController.playerPosition, Time.deltaTime * 1000);

            if (Vector2.Distance(hookController.playerPosition, hookController.hookPosition) < 0.1f)
            {
                hookController.GetComponent<DistanceJoint2D>().enabled = false;
                hookController.gameObject.SetActive(false);
            }
        }

        // (��) Ʃ�丮��� ���� �������� ������ ������ �� ����ߴ� �Լ�
        public void ResetHookState()
        {
            if (GameManager.Instance.GetIsTutorial())
            {
                hookController.GetComponent<DistanceJoint2D>().enabled = false;
            }
            else
            {
                hookController.GetComponent<DistanceJoint2D>().enabled = false;
            }
            hookController.gameObject.SetActive(false);
        }
    }
}

