using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

namespace HookControlState
{
    public class HookController : MonoBehaviour
    {
        public HookState idleState, fireState, attachState;
        public HookStateContext hookStateContext;
        private static float launchSpeed = 15f;
        private bool isMouseClicked = false;

        public LineRenderer lineRenderer;
        public Vector3 playerPosition; // �θ� ������Ʈ�� �÷��̾��� ������(World)
        public Vector3 goalPosition; // ���콺�� Ŭ���� ������ ������(World)

        public delegate void CollisionHandler(Collider2D collision);
        public event CollisionHandler OnCollision;


        void Start()
        {
            hookStateContext = new HookStateContext(this);
            idleState = new HookIdleState();
            fireState = new HookFireState();
            attachState = new HookAttachState();
            InitLineRendererAndHook();
            hookStateContext.ChangeState(idleState);
        }

        void Update()
        {
            playerPosition = transform.parent.position;
            UpdateLineRenderer();
            if (hookStateContext.currentState != null)
            {
                hookStateContext.currentState.Update();
            }
        }

        public void UpdateLineRenderer()
        {
            if (lineRenderer != null)
            {
                lineRenderer.SetPosition(0, playerPosition);
                lineRenderer.SetPosition(1, transform.position);
            }
        }

        void OnMouseClick(Vector3 mousePosition)
        {
            isMouseClicked = true;
            goalPosition = mousePosition;
        }

        void OnEnable()
        {
            PlayerMovement.MouseClickEvent += OnMouseClick;
        }

        void InitLineRendererAndHook()
        {
            lineRenderer.positionCount = 2;
            lineRenderer.endWidth = lineRenderer.startWidth = 0.05f;
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPosition(0, playerPosition); // Player�� ������
            lineRenderer.SetPosition(1, transform.position);
            SetHookEnabled(false);
        }

        public void SetHookEnabled(bool val)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = val;
            gameObject.GetComponent<BoxCollider2D>().enabled = val;
        }
        public float GetLaunchSpeed() { return launchSpeed; }
        public bool GetIsMouseClicked() { return isMouseClicked; }
        public void SetIsMouseClicked(bool val) { isMouseClicked = val; }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacles"))
            {
                Debug.Log("��ֹ��� �ε���");
                // currentState�� HookFireState���� Ȯ���ϰ� �޼��� ȣ��
                if (hookStateContext.currentState is HookFireState)
                {
                    (hookStateContext.currentState as HookFireState).
                        HandleCollisionWithObstacle(collision.transform.position);
                }
                else
                {
                    Debug.LogError("���� ���°� HookFireState�� �ƴմϴ�.");
                }
            }

            if (collision.CompareTag("FinishObject"))
            {
                GameManager.Instance.LoadSceneWithName("BossScene");
            }
        }
    }
}