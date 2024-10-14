using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HookControlState
{
    //public enum State
    //{
    //    IDLE,
    //    FIRE,
    //    ATTACH,
    //}

    public interface HookState
    {
        void Action(HookController controller);
    }

    public class HookStateContext
    {
        public HookState currentState { get; private set; }
        private HookController hookController;

        public HookStateContext(HookController controller)
        {
            this.hookController = controller;
        }

        public void DoAction()
        {
            currentState.Action(hookController);
        }

        public void DoAction(HookState state)
        {
            currentState = state;
            currentState.Action(hookController);
        }
    }

    public class HookController : MonoBehaviour
    {
        public HookState idleState, fireState, attachState;
        private HookStateContext hookStateContext;
        private static float launchSpeed = 20f;

        public LineRenderer lineRenderer;
        public Transform hook;

        void Start()
        {
            hookStateContext = new HookStateContext(this);
            idleState = gameObject.AddComponent<HookIdleState>();
            fireState = gameObject.AddComponent<HookFireState>();
            attachState = gameObject.AddComponent<HookAttachState>();
            hookStateContext.DoAction(idleState);
        }

        public void HookIdle()
        {
            hookStateContext.DoAction(idleState);
        }

        public void HookFire()
        {
            hookStateContext.DoAction(fireState);
        }

        public void HookAttach()
        {
            hookStateContext.DoAction(attachState);

        }

        public float GetLaunchSpeed() { return launchSpeed; }
    }
}