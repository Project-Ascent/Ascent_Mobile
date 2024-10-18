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

        public void Enter(HookController controller)
        {
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;
            }
            RetractHook();
            hookController.SetIsMouseClicked(false);
            Debug.Log("HookIdleState ����");
        }

        public void Update()
        {
           // ���콺 ��Ŭ�� ������ HookFire�� �̵�
           if (hookController.GetIsMouseClicked())
           {
                hookController.hookStateContext.ChangeState(hookController.fireState, hookController.goalPosition);

           }
        }


        public void Exit()
        {

        }

        void RetractHook()
        {
            Debug.Log("RetractHook ȣ��");
            hookController.transform.position = Vector2.MoveTowards(hookController.transform.position, hookController.playerPosition, Time.deltaTime * 1000);
            if (Vector2.Distance(hookController.playerPosition, hookController.transform.position) < 0.1f)
            {
                hookController.GetComponent<DistanceJoint2D>().enabled = false;
                hookController.SetHookEnabled(false);
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

