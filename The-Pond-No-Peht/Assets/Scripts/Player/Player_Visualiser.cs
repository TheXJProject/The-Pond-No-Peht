using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Visualiser : MonoBehaviour
{
    [SerializeField] Player_Controller playerStatsAccess;
    [SerializeField] Transform bodyPositioning;

    private void Update()
    {
        bodyPositioning.position = new Vector3(transform.position.x, transform.position.y + playerStatsAccess.playerHeight, 0);
    }
}
