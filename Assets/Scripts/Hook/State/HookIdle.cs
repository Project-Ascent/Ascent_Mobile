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
            if (!hookController) // null이거나 비활성화 상태인지 확인
            {
                hookController = controller;
            }
            RetractHook();
            hookController.IsMouseClicked = false;
            Debug.Log("HookIdleState 진입");
        }

        public void Update()
        {
            // hookPosition이 항상 playerPosition이어야 함.
            hookController.transform.position = hookController.PlayerPosition;

           // 마우스 좌클릭 받으면 HookFire로 이동
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

