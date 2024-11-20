using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace HookControlState
{
    public interface HookState
    {
        public void Enter(HookController controller);
        public void Update();
        public void Exit();
    }

    public class HookStateContext
    {
        public HookState currentState { get; private set; }
        private HookController hookController;

        public HookStateContext(HookController controller)
        {
            hookController = controller;
        }

        public void ChangeState()
        {
            currentState = new HookIdleState();
            currentState.Enter(hookController);
        }

        public void ChangeState(HookState nextState)
        {
            if (currentState == null)
            {
                currentState = nextState;
                currentState.Enter(hookController);
            }
            currentState.Exit();
            currentState = nextState;
            currentState.Enter(hookController);
        }
    }
}