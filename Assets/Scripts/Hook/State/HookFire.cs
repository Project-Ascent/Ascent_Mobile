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
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;
            }
            targetPosition = Camera.main.ScreenToWorldPoint(hookController.GoalPosition);
            hookController.gameObject.SetActive(true);
            hookController.SetHookEnabled(true);
            hookController.playerGO.GetComponent<PlayerMovement>().CanMove = false;
            Debug.Log("HookFireState ����");
        }

        public void Exit()
        {
            hookController.playerGO.GetComponent<PlayerMovement>().CanMove = true;
            hookController.transform.position = collisionPosition;
            // Debug.Log("HookFire Exit �Լ� ȣ��");
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
            // (�÷��̾� ������, �� ������)
            return Vector2.Distance(hookController.PlayerPosition, hookController.transform.position) >= curFireMaxRange;
        }

        public void HandleCollisionWithObstacle(Vector2 collisionPoint)
        {
            hookController.transform.position = collisionPosition = collisionPoint;
            hookController.hookStateContext.ChangeState(hookController.attachState);
        }
    }
}
