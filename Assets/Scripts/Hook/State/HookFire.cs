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
            if (!hookController) // null이거나 비활성화 상태인지 확인
            {
                hookController = controller;
            }
            hookController.SetIsMouseClicked(false);
        }


        public void Enter(HookController controller, Vector2 clickPosition)
        {
            if (!hookController) // null이거나 비활성화 상태인지 확인
            {
                hookController = controller;
            }
            targetPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            Debug.Log("HookFireState 진입");
            hookController.gameObject.SetActive(true);
            hookController.SetHookEnabled(true);

            // c# min뭐였지
            maxRange = min(maxRange, Vector2.Distance(hookController.playerPosition, hookController.transform.position));
        }

        public void Update()
        {
            MoveHookTowardsTarget();
            if (CheckMaxRange())
            {
                // MaxRange에 도달하면 다시 idleState로 이동
                hookController.hookStateContext.ChangeState(hookController.idleState);
            }

            // 안부딪혔는데 targetPosition까지 도달하면 다시 idleState로 이동


            // 플랫폼에 부딪히면 attachState로 이동
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
            // (플레이어 포지션, 훅 포지션)
            Debug.Log(Vector2.Distance(hookController.playerPosition, hookController.transform.position));
            if (Vector2.Distance(hookController.playerPosition, hookController.transform.position) > maxRange) { return true; }
            else { return false; }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacles"))
            {
                Debug.Log("부딪힘");
            }

            if (collision.CompareTag("FinishObject"))
            {
                GameManager.Instance.LoadSceneWithName("BossScene");
            }
        }
    }
}
