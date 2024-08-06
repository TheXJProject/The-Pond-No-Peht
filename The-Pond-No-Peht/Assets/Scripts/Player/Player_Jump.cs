using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Jump : MonoBehaviour
{
    public PlayerController playerControls;

    [SerializeField] float preJumpTimeSeconds = 0.05f;
    [SerializeField] float timeSincePreJump = 10f;
    [SerializeField] float jumpVelocity = 10f;

    [SerializeField] Player_Controller playerController;

    InputAction jump;

    private void Awake()
    {
        playerControls = new PlayerController();
    }

    private void OnEnable()
    {
        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.started += jumpPressed;
    }

    private void OnDisable()
    {
        jump.started -= jumpPressed;
        jump.Disable();
    }

    private void FixedUpdate()
    {
        // If time since pressed jump is within set preJump time, then commence jump if on the ground
        if (timeSincePreJump < preJumpTimeSeconds)
        {
            if (playerController.playerOnSurface) { commenceJump(); }
            timeSincePreJump += Time.deltaTime;
        }
    }
    private void jumpPressed(InputAction.CallbackContext context)
    {
        // If jump pressed, commence jump if not on the floor, otherwise begin timer to measure since jump was pressed
        if (playerController.playerOnSurface) { commenceJump(); }
        else { timeSincePreJump = 0f; }
    }

    private void commenceJump()
    {
        playerController.playerOnSurface = false;
        playerController.playerVerticalVelocity = jumpVelocity;
    }
}
