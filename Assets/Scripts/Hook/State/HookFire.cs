using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookControlState
{
    public class HookFireState : MonoBehaviour, HookState
    {
        private HookController hookController;
        private Vector2 mouseDirection;
        private int maxRange;

        public Transform hook;

        public void Action(HookController controller)
        {
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;

            }
        }

        void Update()
        {
            FireHook();
            if (CheckMaxRange())
            {
                // ���� ��ȭ
            }
        }

        void FireHook(Vector2 direction)
        {
            hook.position = transform.position;
            mouseDirection = Camera.main.ScreenToWorldPoint(direction) - transform.position;
            hook.gameObject.SetActive(true);
            hook.Translate(mouseDirection.normalized * Time.deltaTime * hookController.GetLaunchSpeed());
            CheckMaxRange();
        }

        bool CheckMaxRange()
        {
            if (Vector2.Distance(transform.position, hook.position) > maxRange) { return true; }
            else { return false; }
        }

    }
}
