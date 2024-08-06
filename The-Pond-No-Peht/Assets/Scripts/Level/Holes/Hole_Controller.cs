using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole_Controller : MonoBehaviour
{
    public bool playerInThisHole = false;
    public int holeLevel = 0;

    [SerializeField] Player_Controller accessPlayerStats;
    [SerializeField] Transform playerBasePosition;
    [SerializeField] Collider2D holeArea;

    int amountInHole;
    Vector2[] baseCoords = new Vector2[4];

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && accessPlayerStats.playerLevel == holeLevel)
        {
            Debug.Log("collided with player");
            baseCoords[0] = playerBasePosition.position + new Vector3(0, 0.5f * playerBasePosition.lossyScale.y, 0);
            baseCoords[1] = playerBasePosition.position - new Vector3(0, 0.5f * playerBasePosition.lossyScale.y, 0);
            baseCoords[2] = playerBasePosition.position + new Vector3(0.5f * playerBasePosition.lossyScale.x, 0, 0);
            baseCoords[3] = playerBasePosition.position - new Vector3(0.5f * playerBasePosition.lossyScale.x, 0, 0);

            amountInHole = 0;
            for (int i = 0; i < 4; i++)
            {
                if (holeArea.bounds.Contains(baseCoords[i])) { amountInHole++; }
            }
            if (amountInHole == 4) 
            { 
                playerInThisHole = true; 
                accessPlayerStats.playerLevel = -10;
                accessPlayerStats.playerOnSurface = false;
            }
            else 
            { 
                playerInThisHole = false;
                accessPlayerStats.playerLevel = holeLevel;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInThisHole = false;
            accessPlayerStats.playerLevel = holeLevel;
        }
    }
}
