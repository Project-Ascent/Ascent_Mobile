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
            hookController.IsMouseClicked = false;
            Debug.Log("HookIdleState ����");
        }

        public void Update()
        {
            // hookPosition�� �׻� playerPosition�̾�� ��.
            hookController.transform.position = hookController.PlayerPosition;

           // ���콺 ��Ŭ�� ������ HookFire�� �̵�
           if (hookController.IsMouseClicked)
           {
                hookController.hookStateContext.ChangeState(hookController.fireState);
           }
        }

        public void Exit()
        {

        }

        void RetractHook()
        {
            hookController.SetHookEnabled(false);
            hookController.GetComponent<DistanceJoint2D>().enabled = false;
            hookController.transform.position = hookController.PlayerPosition;
        }
    }
}

