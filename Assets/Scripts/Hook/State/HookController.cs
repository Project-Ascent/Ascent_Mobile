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
        public Vector3 playerPosition; // �÷��̾��� ������(World)
        public Vector3 goalPosition; // ���콺�� Ŭ���� ������ ������(World)

        public delegate void CollisionHandler(Collider2D collision);
        public event CollisionHandler OnCollision;
        public GameObject playerGO;

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
            playerPosition = playerGO.transform.position;
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
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacles"))
            {
                Debug.Log("��ֹ��� �ε���");
                // currentState�� HookFireState���� Ȯ���ϰ� �޼��� ȣ��
                if (hookStateContext.currentState is HookFireState)
                {
                    Vector2 collisionPoint = other.ClosestPoint(transform.position);
                    (hookStateContext.currentState as HookFireState).
                        HandleCollisionWithObstacle(collisionPoint);
                }
                else
                {
                    Debug.LogError("���� ���°� HookFireState�� �ƴմϴ�.");
                }
            }

            if (other.CompareTag("FinishObject"))
            {
                GameManager.Instance.LoadSceneWithName("BossScene");
            }
        }
    }
}