using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace HookControlState
{
    public class HookFireState : HookState
    {
        private HookController hookController;
        private Vector2 targetPosition;
        private Vector2 collisionPosition;
        private const float maxRange = 10f;
        private float curFireMaxRange;

        public void Update()
        {
            curFireMaxRange = Math.Min(maxRange, Vector2.Distance(hookController.PlayerPosition, targetPosition));
            MoveHookTowardsTarget();
            if (CheckMaxRange())
            {
                hookController.hookStateContext.ChangeState(hookController.idleState);
            }
        }

        public void Enter(HookController controller)
        {
            if (!hookController) // null이거나 비활성화 상태인지 확인
            {
                hookController = controller;
            }
            targetPosition = Camera.main.ScreenToWorldPoint(hookController.GoalPosition);
            hookController.gameObject.SetActive(true);
            hookController.SetHookEnabled(true);
            hookController.playerGO.GetComponent<PlayerMovement>().CanMove = false;
            Debug.Log("HookFireState 진입");
        }

        public void Exit()
        {
            hookController.playerGO.GetComponent<PlayerMovement>().CanMove = true;
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
                Time.deltaTime * hookController.LaunchSpeed);
        }

        bool CheckMaxRange()
        {
            // (플레이어 포지션, 훅 포지션)
            return Vector2.Distance(hookController.PlayerPosition, hookController.transform.position) >= curFireMaxRange;
        }

        public void HandleCollisionWithObstacle(Vector2 collisionPoint)
        {
            hookController.transform.position = collisionPosition = collisionPoint;
            hookController.hookStateContext.ChangeState(hookController.attachState);
        }
    }
}
