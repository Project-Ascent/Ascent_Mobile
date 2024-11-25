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
        private Vector2 firedPosition; // 훅이 최초로 발사된 위치
        private Vector2 targetPosition; // 목표 지점의 위치
        private Vector2 collisionPosition; // 충돌 지점의 위치
        private const float maxRange = 10f;
        private float curFireMaxRange; 

        public void Enter(HookController controller)
        {
            if (!hookController) // null이거나 비활성화 상태인지 확인
            {
                hookController = controller;
            }
            firedPosition = hookController.transform.position;
            targetPosition = Camera.main.ScreenToWorldPoint(hookController.GoalPosition);
            curFireMaxRange = Math.Min(maxRange, Vector2.Distance(firedPosition, targetPosition));
            hookController.SetHookEnabled(true);
            Debug.Log("HookFireState 진입");
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
            hookController.transform.position = collisionPosition;
            // Debug.Log("HookFire Exit 함수 호출");
        }

        void MoveHookTowardsTarget()
        {
            hookController.gameObject.SetActive(true);

            Vector2 worldHookPosition = hookController.transform.position;

            hookController.transform.position = Vector2.MoveTowards
                (worldHookPosition,
                targetPosition, 
                Time.deltaTime * hookController.LaunchSpeed);
        }

        bool CheckMaxRange()
        {
            // (플레이어 포지션, 훅 포지션)
            return Vector2.Distance(firedPosition, hookController.transform.position) >= curFireMaxRange;
        }

        public void HandleCollisionWithObstacle(Vector2 collisionPoint)
        {
            hookController.transform.position = collisionPosition = collisionPoint;
            hookController.hookStateContext.ChangeState(hookController.attachState);
        }
    }
}
