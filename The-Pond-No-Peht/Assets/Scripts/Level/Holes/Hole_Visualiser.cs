using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole_Visualiser : MonoBehaviour
{
    [SerializeField] SpriteRenderer holeOuter;
    [SerializeField] Hole_Controller accessHoleStats;
    [SerializeField] int layerToHidePlayer = 0;
    [SerializeField] int layerToShowPlayer = 100;

    void Update()
    {
        if (accessHoleStats.playerInThisHole == true) { holeOuter.sortingOrder = layerToHidePlayer; }
        else { holeOuter.sortingOrder = layerToShowPlayer; }
    }
}
