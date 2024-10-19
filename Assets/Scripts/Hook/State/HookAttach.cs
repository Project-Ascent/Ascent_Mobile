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
            hookController.GetComponent<DistanceJoint2D>().enabled = true;
            hookController.SetIsMouseClicked(false);
            Debug.Log("HookAttachState 진입");
        }

        public void Update()
        {
            hookController.lineRenderer.SetPosition(0, hookController.playerPosition);
            hookController.lineRenderer.SetPosition(1, hookController.transform.position);
            if (hookController.GetIsMouseClicked())
            {
                hookController.hookStateContext.ChangeState(hookController.idleState);
            }
        }

        public void Exit()
        {
            hookController.GetComponent<DistanceJoint2D>().enabled = false;
        }

        void Start()
        {
        }

    }
}
