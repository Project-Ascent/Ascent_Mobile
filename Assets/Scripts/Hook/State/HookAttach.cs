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
            if (!hookController) // null�̰ų� ��Ȱ��ȭ �������� Ȯ��
            {
                hookController = controller;
            }

            DistanceJoint2D joint = hookController.GetComponent<DistanceJoint2D>();
            if (joint != null)
            {
                joint.enabled = true;
            }
            hookController.SetIsMouseClicked(false);
            Debug.Log("HookAttachState ����");
        }

        public void Update()
        {
            Debug.Log(hookController.playerPosition);
            Debug.Log(hookController.transform.position);
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
