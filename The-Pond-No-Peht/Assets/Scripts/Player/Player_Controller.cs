using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public int playerLevel = 0;
    public float playerHeight = 0f;
    public float playerVerticalVelocity = 0f;
    public float playerGravityStrength = 1f;
    public float slightFloatBoundary = 1f;
    public float slightFloatReduction = 0.2f;
    public bool playerOnSurface = true;
    public bool playerAboveSurface = true;

    public InputAction move;
    public InputAction jump;

    //float recordHeight = 0f;

    private void FixedUpdate()
    {
        if (!playerAboveSurface) { playerOnSurface = false; }
        if (!playerOnSurface)
        {
            playerHeight += playerVerticalVelocity * Time.deltaTime;
            if (math.abs(playerVerticalVelocity) < slightFloatBoundary) { playerVerticalVelocity -= playerGravityStrength * slightFloatReduction * Time.deltaTime; }
            else { playerVerticalVelocity -= playerGravityStrength * Time.deltaTime; }
        }
        else
        {
            playerVerticalVelocity = 0f;
        }
        if (playerHeight <= playerLevel && playerAboveSurface)
        {
            playerHeight = playerLevel;
            playerOnSurface = true;
        }
        //if (recordHeight > playerHeight) { Debug.Log(recordHeight); }
        //if (recordHeight < playerHeight) { recordHeight = playerHeight; }
    }
}
