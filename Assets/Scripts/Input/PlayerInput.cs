using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerControls playerControls;
    private InputAction move;
    public Vector2 moveDirection;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        ActivateInput();
    }

    private void OnDisable()
    {
        DeactivateInput();
    }
    public void ActivateInput()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    public void DeactivateInput()
    {
        move.Disable();
    }
    public void Update()
    {
        // Set the movement direction input vector
        moveDirection = move.ReadValue<Vector2>();
    }
}
