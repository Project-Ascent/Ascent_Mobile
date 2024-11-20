using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookControlState
{
    public class HookAttachState : HookState
    {
        private HookController hookController;

        public void Enter(HookController controller)
        {
            if (!hookController) // null이거나 비활성화 상태인지 확인
            {
                hookController = controller;
            }

            DistanceJoint2D joint = hookController.GetComponent<DistanceJoint2D>();
            if (joint != null)
            {
                joint.enabled = true;
            }
            hookController.IsMouseClicked = false;
            Debug.Log("HookAttachState 진입");
        }

        public void Update()
        {
            hookController.LineRenderer.SetPosition(0, hookController.PlayerPosition);
            hookController.LineRenderer.SetPosition(1, hookController.transform.position);
            if (hookController.IsMouseClicked)
            {
                hookController.hookStateContext.ChangeState(hookController.idleState);
            }
        }

        public void Exit()
        {
            hookController.GetComponent<DistanceJoint2D>().enabled = false;
        }
    }
}
