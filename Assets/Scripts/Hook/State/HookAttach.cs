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
            if (!hookController) // null이거나 비활성화 상태인지 확인
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
