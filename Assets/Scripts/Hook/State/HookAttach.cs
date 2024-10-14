using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookControlState
{
    public class HookAttachState : MonoBehaviour, HookState
    {
        private HookController hookController;

        public void Action(HookController controller)
        {
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;

            }
        }

        void RetractHook()
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 1000);

            if (Vector2.Distance(transform.position, hook.position) < 0.1f)
            {
                ResetHookState();
                isMoveButtonPressed = false; // ��ư�� ���� �� ������ false�� ����
            }
        }

    }
}
