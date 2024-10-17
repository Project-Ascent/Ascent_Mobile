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
            if (!hookController) // null이거나 비활성화 상태인지 확인
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

        // (구) 튜토리얼과 실제 스테이지 로직이 갈렸을 때 사용했던 함수
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

