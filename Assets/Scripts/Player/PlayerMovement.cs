using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public delegate void OnMouseClick(Vector3 mousePosition);
    public static event OnMouseClick MouseClickEvent;

    PlayerInputAction action;
    InputAction moveAction, clickAction;
    PlayerAnimation playerAnimation;
    private float movementSpeed = 0.08f;
    private bool canMove = true;
    private float currentRotationY = 0;

    private void Awake()
    {
        action = new PlayerInputAction();
        moveAction = action.Player.Move;
        moveAction.Enable();
        moveAction.started += OnMoveStarted;
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;

        clickAction = action.Player.Click;
        clickAction.Enable();
        clickAction.started += OnClickStarted;

        playerAnimation = GetComponent<PlayerAnimation>();
    }

    void OnMoveStarted(InputAction.CallbackContext context)
    {
        if (!canMove) return;
        Vector2 inputVector = context.ReadValue<Vector2>();
        ChangePlayerRotate(inputVector.x);

        if (playerAnimation != null)
        {
            playerAnimation.PlayWalkAnimation();
        }
    }

    void OnMovePerformed(InputAction.CallbackContext context) {}

    void OnMoveCanceled(InputAction.CallbackContext context)
    {
        if (!canMove) return;
        if (playerAnimation != null)
        {
            playerAnimation.PlayIdleAnimation();
        }
    }

    void OnClickStarted(InputAction.CallbackContext context)
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        if (MouseClickEvent != null)
        {
            MouseClickEvent.Invoke(mousePosition);
        }
        else
        {
            Debug.Log("MouseClickEvent is null");
        }
    }

    void Move(float x)
    {
        Vector3 moveDirection = new Vector3(x * movementSpeed, 0, 0);
        this.transform.Translate(moveDirection, Space.World);
    }

    void ChangePlayerRotate(float keyboardVectorX)
    {
        if (keyboardVectorX < 0) // ���� �̵� + ������ �ٶ�
        {
            currentRotationY = 180;
        }
        if (keyboardVectorX > 0) // ������ �̵� + ���� �ٶ�
        {
            currentRotationY = 0;
        }

        if (currentRotationY != transform.eulerAngles.y)
        {
            Vector3 newRotation = new Vector3(0, currentRotationY, 0);
            transform.eulerAngles = newRotation;
        }
    }

    void Update()
    {
        if (canMove)
        {
            Vector2 keyboardVector = moveAction.ReadValue<Vector2>();
            Move(keyboardVector.x);
        }
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
        ForceAnimation(canMove);
    }

    public void ForceAnimation(bool canMove)
    {
        if (!canMove)
        {
            playerAnimation.PlayIdleAnimation();
        }
        if (canMove)
        {
            if (moveAction.ReadValue<Vector2>().x == 0)
            {
                playerAnimation.PlayIdleAnimation();
            }
            else
            {
                playerAnimation.PlayWalkAnimation();
                ChangePlayerRotate(moveAction.ReadValue<Vector2>().x);
            }
        }
    }
}
