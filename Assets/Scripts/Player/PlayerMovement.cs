using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputAction action;
    InputAction moveAction;
    private float movementSpeed = 0.08f;

    PlayerAnimation playerAnimation;

    private void Awake()
    {
        action = new PlayerInputAction();
        moveAction = action.Player.Move;
        moveAction.Enable();
        moveAction.started += OnMoveStarted;
        moveAction.canceled += OnMoveCanceled;
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

    void Update()
    {
        Vector2 keyboardVector = moveAction.ReadValue<Vector2>();
        Move(keyboardVector.x);
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
}
