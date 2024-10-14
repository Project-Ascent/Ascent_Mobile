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
            if (!hookController) // null이거나 비활성화 상태인지 확인
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
                isMoveButtonPressed = false; // 버튼을 떼면 이 변수를 false로 설정
            }
        }

    }
}
