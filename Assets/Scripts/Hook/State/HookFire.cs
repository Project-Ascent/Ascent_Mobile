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
        private Vector2 firedPosition; // ���� ���ʷ� �߻�� ��ġ
        private Vector2 targetPosition; // ��ǥ ������ ��ġ
        private Vector2 collisionPosition; // �浹 ������ ��ġ
        private const float maxRange = 10f;
        private float curFireMaxRange; 

        public void Enter(HookController controller)
        {
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;
            }
            firedPosition = hookController.transform.position;
            targetPosition = Camera.main.ScreenToWorldPoint(hookController.GoalPosition);
            curFireMaxRange = Math.Min(maxRange, Vector2.Distance(firedPosition, targetPosition));
            hookController.SetHookEnabled(true);
            Debug.Log("HookFireState ����");
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
            // Debug.Log("HookFire Exit �Լ� ȣ��");
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
            // (�÷��̾� ������, �� ������)
            return Vector2.Distance(firedPosition, hookController.transform.position) >= curFireMaxRange;
        }

        public void HandleCollisionWithObstacle(Vector2 collisionPoint)
        {
            hookController.transform.position = collisionPosition = collisionPoint;
            hookController.hookStateContext.ChangeState(hookController.attachState);
        }
    }
}
