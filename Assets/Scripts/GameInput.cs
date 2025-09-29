using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputSystem playerInputSystem;

    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputSystem.Player.Move.ReadValue<Vector2>();

        return inputVector.normalized;
    }

    public Vector2 GetMousePosition()
    {
        Vector2 inputMousePos = playerInputSystem.Player.Aim.ReadValue<Vector2>();
        return inputMousePos;
    }
}
