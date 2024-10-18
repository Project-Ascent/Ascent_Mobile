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

    private void Awake()
    {
        action = new PlayerInputAction();
        moveAction = action.Player.Move;
        moveAction.Enable();
        moveAction.started += OnMoveStarted;
        moveAction.canceled += OnMoveCanceled;

        clickAction = action.Player.Click;
        clickAction.Enable();
        clickAction.started += OnClickStarted;

        playerAnimation = GetComponent<PlayerAnimation>();
    }

    void OnMoveStarted(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        if (inputVector.x < 0 && transform.rotation.y == 0)
        {
            Rotate(180);
        }

        if (inputVector.x > 0 && transform.rotation.y != 0)
        {
            Rotate(0);
        }

        if (playerAnimation != null)
        {
            playerAnimation.PlayWalkAnimation();
        }
    }

    void OnMoveCanceled(InputAction.CallbackContext context)
    {
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
        Vector3 moveDirection = new Vector3(
                x * movementSpeed, 0, 0);
        // this.transform.Translate(moveDirection, Space.Self); // 플레이어의 로컬 좌표 기준으로 이동
        this.transform.Translate(moveDirection, Space.World); // 월드 좌표 기준으로 이동
    }

    void Rotate(float yRotation)
    {
        Vector3 newRotation = new Vector3(0, yRotation, 0);
        this.transform.eulerAngles = newRotation;
    }


    void Update()
    {
        Vector2 keyboardVector = moveAction.ReadValue<Vector2>();
        Move(keyboardVector.x);
    }
}
