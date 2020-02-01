using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTeleporter : MonoBehaviour
{
    public CatController cat;
    public CatTeleportPosition[] catTeleportPositions;
    private int currentTeleport = 0;

    private void Start()
    {
        NextTeleport();
        cat.OnActionFinished += NextTeleport;
    }

    void NextTeleport()
    {
        if (currentTeleport > catTeleportPositions.Length-1)
            return;
        cat.TeleportTo(
            catTeleportPositions[currentTeleport].transform.position,
            catTeleportPositions[currentTeleport].transform.forward);
        currentTeleport++;
    }
}
