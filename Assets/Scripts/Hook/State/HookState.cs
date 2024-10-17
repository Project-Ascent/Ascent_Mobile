using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace HookControlState
{
    public interface HookState
    {
        void Handle(HookController controller);
    }

    public class HookStateContext
    {
        public HookState currentState { get; private set; }
        private HookController hookController;

        public HookStateContext(HookController controller)
        {
            this.hookController = controller;
        }

        public void ChangeState()
        {
            currentState.Handle(hookController);
        }

        public void ChangeState(HookState state)
        {
            currentState = state;
            currentState.Handle(hookController);
        }
    }

    public class HookController : MonoBehaviour
    {
        public HookState idleState, fireState, attachState;
        private HookStateContext hookStateContext;
        private static float launchSpeed = 20f;

        public LineRenderer lineRenderer;
        public Vector3 playerPosition;
        public Vector3 hookPosition;


        void Start()
        {
            hookStateContext = new HookStateContext(this);
            //idleState = gameObject.AddComponent<HookIdleState>();
            //fireState = gameObject.AddComponent<HookFireState>();
            //attachState = gameObject.AddComponent<HookAttachState>();
            idleState = new HookIdleState();
            fireState = new HookFireState();
            attachState = new HookAttachState();
            InitLineRendererAndHook();
            hookStateContext.ChangeState(idleState);
        }

        void Update()
        {
            // �θ� ������Ʈ�� Player�� Transform�� ������
            playerPosition = transform.parent.position;
            hookPosition = transform.position;

            // ���� ��ġ�� ���ÿ� ������ ���� ó��
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                // UI ��ġ�� ȭ�� ��ġ ����
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    // ȭ�� ��ġ�� ��
                    if (touch.phase == UnityEngine.TouchPhase.Began)
                    {
                        if (hookStateContext.currentState == idleState)
                        {
                            // HookFire�� ���� ����
                            HookFire(touch.position);
                        }
                        else
                        {
                            // ���� �߻����̰ų�, �÷����� �Ŵ޷� �������� HookIdle�� ���� ����
                            HookIdle();
                        }
                    }
                }
            }
        }

        void InitLineRendererAndHook()
        {
            lineRenderer.positionCount = 2;
            lineRenderer.endWidth = lineRenderer.startWidth = 0.05f;
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPosition(0, playerPosition); // Player�� ������
            lineRenderer.SetPosition(1, transform.position);

            // gameObject.SetActive(true);
        }

        public void HookIdle()
        {
            hookStateContext.ChangeState(idleState);
        }

        public void HookFire(Vector2 touchPosition)
        {
            hookStateContext.ChangeState(fireState);
            (fireState as HookFireState).Handle(this, touchPosition);
        }

        public void HookAttach()
        {
            hookStateContext.ChangeState(attachState);

        }

        public float GetLaunchSpeed() { return launchSpeed; }
    }
}