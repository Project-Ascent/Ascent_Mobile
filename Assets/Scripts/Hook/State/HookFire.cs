using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookControlState
{
    public class HookFireState : HookState
    {
        private HookController hookController;
        private Vector2 mouseDirection;
        private int maxRange;
        private Vector2 touchPosition;

        public void Handle(HookController controller)
        {
            if (!hookController) // null이거나 비활성화 상태인지 확인
            {
                hookController = controller;
            }
        }

        public void Handle(HookController controller, Vector2 touchPosition)
        {
            if (!hookController) // null이거나 비활성화 상태인지 확인
            {
                hookController = controller;
            }
            this.touchPosition = touchPosition; 

        }

        void Update()
        {
            FireHook(touchPosition);
            if (CheckMaxRange())
            {
                // HookIdle로 상태 변화
                hookController.HookIdle();
            }
        }

        void FireHook(Vector2 touchPosition)
        {
            mouseDirection = Camera.main.ScreenToWorldPoint(touchPosition) - hookController.hookPosition;
            hookController.gameObject.SetActive(true);
            hookController.transform.Translate(mouseDirection.normalized * Time.deltaTime * hookController.GetLaunchSpeed());
            CheckMaxRange();
        }

        bool CheckMaxRange()
        {
            // (플레이어 포지션, 훅 포지션)
            if (Vector2.Distance(hookController.playerPosition, hookController.hookPosition) > maxRange) { return true; }
            else { return false; }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacles"))
            {
                // HookAttached로 상태 변화
                hookController.HookAttach();
            }

            if (collision.CompareTag("FinishObject"))
            {
                GameManager.Instance.LoadSceneWithName("BossScene");
            }
        }

    }
}
