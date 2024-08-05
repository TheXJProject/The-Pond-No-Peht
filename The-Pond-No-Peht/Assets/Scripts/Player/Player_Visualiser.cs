using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Visualiser : MonoBehaviour
{
    Player_Controller playerStatsAccess;
    Transform bodyPositioning;
    private void Awake()
    {
        playerStatsAccess = GetComponent<Player_Controller>();
        bodyPositioning = transform.GetChild(0).transform;
    }

    private void Update()
    {
        bodyPositioning.position = new Vector3(transform.position.x, transform.position.y + playerStatsAccess.playerHeight, 0);
    }
}
