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
            hookController.SetIsMouseClicked(false);
            Debug.Log("HookIdleState 진입");
        }

        public void Update()
        {
            // hookPosition이 항상 playerPosition이어야 함.
            hookController.transform.position = hookController.playerPosition;

           // 마우스 좌클릭 받으면 HookFire로 이동
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
            hookController.transform.position = Vector2.MoveTowards(hookController.transform.position, hookController.playerPosition, Time.deltaTime * 1000);
            if (Vector2.Distance(hookController.playerPosition, hookController.transform.position) < 0.1f)
            {
                hookController.GetComponent<DistanceJoint2D>().enabled = false;
                hookController.SetHookEnabled(false);
            }
        }
    }
}

