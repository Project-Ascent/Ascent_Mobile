using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputAction action;
    InputAction moveAction;
    private float movementSpeed = 1f;

    private void Awake()
    {
        action = new PlayerInputAction();
        moveAction = action.Player.Move;
        moveAction.Enable();
        moveAction.started += OnMoveStarted;
        moveAction.canceled += OnMoveCanceled;
    }

    void OnMoveStarted(InputAction.CallbackContext context)
    {
        // 걷는 애니메이션 실행
    }

    void OnMoveCanceled(InputAction.CallbackContext context)
    {
        // Idle 애니메이션 실행
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
        this.transform.Translate(moveDirection, Space.Self);
    }
}
