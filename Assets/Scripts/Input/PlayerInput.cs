using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerControls playerControls;
    private InputAction move;
    private InputAction paint;
    public Vector2 moveDirection;
    public LocomotionHandler locomotionHandler;

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
        paint = playerControls.Player.Paint;
        paint.Enable();
        
    }

    public void DeactivateInput()
    {
        move.Disable();
        paint.Disable();
    }
    private void Start()
    {
        locomotionHandler = GetComponent<LocomotionHandler>();
    }
    public void Update()
    {
        // Set the movement direction input vector
        moveDirection = move.ReadValue<Vector2>();
        if(paint.triggered)
        {
            locomotionHandler.PaintHouse();
        }
    }
    

}
