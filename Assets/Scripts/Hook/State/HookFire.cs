using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace HookControlState
{
    public class HookFireState : HookState
    {
        private HookController hookController;
        private Vector2 targetPosition;
        private Vector2 mouseDirection;
        private int maxRange = 10;

        public void Enter(HookController controller)
        {
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;
            }
            hookController.SetIsMouseClicked(false);
        }


        public void Enter(HookController controller, Vector2 clickPosition)
        {
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;
            }
            targetPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            Debug.Log("HookFireState ����");
            hookController.gameObject.SetActive(true);
            hookController.SetHookEnabled(true);

            // c# min������
            maxRange = min(maxRange, Vector2.Distance(hookController.playerPosition, hookController.transform.position));
        }

        public void Update()
        {
            MoveHookTowardsTarget();
            if (CheckMaxRange())
            {
                // MaxRange�� �����ϸ� �ٽ� idleState�� �̵�
                hookController.hookStateContext.ChangeState(hookController.idleState);
            }

            // �Ⱥε����µ� targetPosition���� �����ϸ� �ٽ� idleState�� �̵�


            // �÷����� �ε����� attachState�� �̵�
            // hookController.hookStateContext.ChangeState(hookController.attachState);
        }

        public void Exit()
        {

        }

        void MoveHookTowardsTarget()
        {
            hookController.gameObject.SetActive(true);
            hookController.transform.position = Vector2.MoveTowards
                (hookController.transform.position,
                targetPosition, 
                Time.deltaTime * hookController.GetLaunchSpeed());
            CheckMaxRange();
        }

        bool CheckMaxRange()
        {
            // (�÷��̾� ������, �� ������)
            Debug.Log(Vector2.Distance(hookController.playerPosition, hookController.transform.position));
            if (Vector2.Distance(hookController.playerPosition, hookController.transform.position) > maxRange) { return true; }
            else { return false; }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacles"))
            {
                Debug.Log("�ε���");
            }

            if (collision.CompareTag("FinishObject"))
            {
                GameManager.Instance.LoadSceneWithName("BossScene");
            }
        }
    }
}
