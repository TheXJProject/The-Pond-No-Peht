using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public float playerHeight = 0f;
    public float playerVerticalVelocity = 0f;
    public float playerGravityStrength = 1f;
    public bool playerOnSurface = true;

    public InputAction move;
    public InputAction jump;

    private void FixedUpdate()
    {
        if (!playerOnSurface)
        {
            playerHeight += playerVerticalVelocity * Time.deltaTime;
            playerVerticalVelocity -= playerGravityStrength * Time.deltaTime;
        }
        else
        {
            playerVerticalVelocity = 0f;
        }
        if (playerHeight <= 0f)
        {
            playerHeight = 0f;
            playerOnSurface = true;
        }
    }
}
