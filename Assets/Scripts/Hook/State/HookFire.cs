using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookControlState
{
    public class HookFireState : HookState
    {
        private HookController hookController;
        private Vector2 targetPosition;
        private Vector2 mouseDirection;
        private Vector2 collisionPosition;
        private float maxRange = 10f;

        public void Enter(HookController controller)
        {
            if (!hookController) // null이거나 비활성화 상태인지 확인
            {
                hookController = controller;
            }
            hookController.SetIsMouseClicked(false);
        }


        public void Enter(HookController controller, Vector2 clickPosition)
        {
            if (!hookController)
            {
                hookController = controller;
            }
            targetPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            hookController.gameObject.SetActive(true);
            hookController.SetHookEnabled(true);
            maxRange = Math.Min(10f, Vector2.Distance(hookController.playerPosition, targetPosition));
            hookController.transform.parent.GetComponent<PlayerMovement>().SetCanMove(false);
            // Debug.Log("HookFireState 진입");
        }

        public void Update()
        {
            MoveHookTowardsTarget();
            if (CheckMaxRange())
            {
                hookController.hookStateContext.ChangeState(hookController.idleState);
            }
        }

        public void Exit()
        {
            hookController.transform.parent.GetComponent<PlayerMovement>().SetCanMove(true);
            hookController.transform.position = collisionPosition;
            // Debug.Log("HookFire Exit 함수 호출");
        }

        void MoveHookTowardsTarget()
        {
            hookController.gameObject.SetActive(true);

            Vector3 worldHookPosition = hookController.transform.position;

            hookController.transform.position = Vector2.MoveTowards
                (worldHookPosition,
                targetPosition, 
                Time.deltaTime * hookController.GetLaunchSpeed());
            CheckMaxRange();
        }

        bool CheckMaxRange()
        {
            // (플레이어 포지션, 훅 포지션)
            if (Vector2.Distance(hookController.playerPosition, hookController.transform.position) >= maxRange) { return true; }
            else { return false; }
        }
        public void HandleCollisionWithObstacle(Vector2 collisionPoint)
        {
            hookController.transform.position = collisionPosition = collisionPoint;
            hookController.hookStateContext.ChangeState(hookController.attachState);
        }
    }
}
