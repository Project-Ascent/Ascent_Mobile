using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookControlState
{
    public class HookAttachState : HookState
    {
        private HookController hookController;


        public void Handle(HookController controller)
        {
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;
            }
            hookController.GetComponent<DistanceJoint2D>().enabled = true;
        }

        void Start()
        {
        }

    }
}
