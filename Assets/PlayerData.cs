using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int lastBuildIndex;
    public float[] lastCheckpoint;

    public PlayerData(PlayerController player)
    {
        lastBuildIndex = PlayerController.scene.buildIndex;
        lastCheckpoint = new float[3];
        lastCheckpoint[0] = player.respawnPoint.x;
        lastCheckpoint[1] = player.respawnPoint.y;
        lastCheckpoint[2] = player.respawnPoint.z;
    } 
}
