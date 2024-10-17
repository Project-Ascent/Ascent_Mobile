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
            // 부모 오브젝트인 Player의 Transform을 가져옴
            playerPosition = transform.parent.position;
            hookPosition = transform.position;

            // 여러 터치가 동시에 들어왔을 때의 처리
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                // UI 터치와 화면 터치 구분
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    // 화면 터치일 때
                    if (touch.phase == UnityEngine.TouchPhase.Began)
                    {
                        if (hookStateContext.currentState == idleState)
                        {
                            // HookFire로 상태 변경
                            HookFire(touch.position);
                        }
                        else
                        {
                            // 훅을 발사중이거나, 플랫폼에 매달려 있을때는 HookIdle로 상태 변경
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
            lineRenderer.SetPosition(0, playerPosition); // Player의 포지션
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