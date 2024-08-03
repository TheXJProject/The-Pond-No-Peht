using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Jump : MonoBehaviour
{
    public float playerheight = 0f;
    public PlayerController playerControls;

    [SerializeField] float preJumpTimeSeconds = 0.05f;
    [SerializeField] float timeSincePreJump = 10f;
    [SerializeField] float jumpVelocity = 10f;

    InputAction jump;
    Player_Controller playerController;

    private void Awake()
    {
        playerControls = new PlayerController();
        playerController = GetComponent<Player_Controller>();
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

        if (timeSincePreJump < preJumpTimeSeconds) 
        {
            if (playerController.playerOnSurface) { commenceJump(); }
            timeSincePreJump += Time.deltaTime; 
        }
    }
    private void jumpPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Jumped");
        if (!playerController.playerOnSurface) 
        {
            timeSincePreJump = 0f;
        }
        else 
        {
            Debug.Log("player Not on surface, so jumped");
            commenceJump(); 
        }
    }

    private void commenceJump()
    {
        Debug.Log("Jump Commenced");
        playerController.playerOnSurface = false;
        playerController.playerVerticalVelocity = jumpVelocity;
    }
}
