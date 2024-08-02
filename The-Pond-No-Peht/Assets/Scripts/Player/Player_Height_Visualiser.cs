using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Height_Visualiser : MonoBehaviour
{
    Player_Jump jumpHeightAccess;
    float height;

    private void OnEnable()
    {
        jumpHeightAccess = GetComponentInParent<Player_Jump>();
        height = jumpHeightAccess.playerheight;
    }

    // Update is called once per frame
    void Update()
    {
        height = jumpHeightAccess.playerheight;
    }
}
