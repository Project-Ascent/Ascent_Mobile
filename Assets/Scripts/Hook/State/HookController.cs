using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

namespace HookControlState
{
    public class HookController : MonoBehaviour
    {
        public HookState idleState, fireState, attachState;
        public HookStateContext hookStateContext;
        public GameObject playerGO;

        private const float launchSpeed = 15f;
        public float LaunchSpeed => launchSpeed; 
        public bool IsMouseClicked { get; set; } = false;

        public LineRenderer LineRenderer { get; private set; }
        public Vector3 PlayerPosition { get; private set; } // �÷��̾��� ������(World)
        public Vector3 GoalPosition { get; private set; } // ���콺�� Ŭ���� ������ ������(World)

        void OnEnable()
        {
            PlayerMovement.MouseClickEvent += OnMouseClick;
        }

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
            PlayerPosition = playerGO.transform.position;
            UpdateLineRenderer();
            if (hookStateContext.currentState != null)
            {
                hookStateContext.currentState.Update();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacles"))
            {
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

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Obstacles"))
            {
                GameObject otherGO = other.gameObject;
                if (otherGO.gameObject.GetComponent<Leaf>() != null)
                {
                    otherGO.gameObject.GetComponent<Leaf>().IsAttachedThisLeaf = false;
                }

                else if (otherGO.gameObject.GetComponent<Bird>() != null)
                {
                    otherGO.gameObject.GetComponent<Bird>().IsAttached = false;
                }
            }
        }

        private void InitLineRendererAndHook()
        {
            LineRenderer = GetComponentsInChildren<LineRenderer>().FirstOrDefault();
            if (LineRenderer != null)
            {
                LineRenderer.positionCount = 2;
                LineRenderer.endWidth = LineRenderer.startWidth = 0.05f;
                LineRenderer.useWorldSpace = true;
                LineRenderer.SetPosition(0, PlayerPosition); // Player�� ������
                LineRenderer.SetPosition(1, transform.position);
            }
            SetHookEnabled(false);
        }

        public void SetHookEnabled(bool val)
        {
            gameObject.SetActive(val);
            gameObject.GetComponent<SpriteRenderer>().enabled = val;
            gameObject.GetComponent<BoxCollider2D>().enabled = val;
        }

        public void UpdateLineRenderer()
        {
            if (LineRenderer != null)
            {
                LineRenderer.SetPosition(0, PlayerPosition);
                LineRenderer.SetPosition(1, transform.position);
            }
        }

        private void OnMouseClick(Vector3 mousePosition)
        {
            IsMouseClicked = true;
            GoalPosition = mousePosition;
        }
    }
}