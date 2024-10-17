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
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;
            }
        }

        public void Handle(HookController controller, Vector2 touchPosition)
        {
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
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
                // HookIdle�� ���� ��ȭ
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
            // (�÷��̾� ������, �� ������)
            if (Vector2.Distance(hookController.playerPosition, hookController.hookPosition) > maxRange) { return true; }
            else { return false; }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacles"))
            {
                // HookAttached�� ���� ��ȭ
                hookController.HookAttach();
            }

            if (collision.CompareTag("FinishObject"))
            {
                GameManager.Instance.LoadSceneWithName("BossScene");
            }
        }

    }
}
