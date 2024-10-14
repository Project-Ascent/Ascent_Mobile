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

    }
}
