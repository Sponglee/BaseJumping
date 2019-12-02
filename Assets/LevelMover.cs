using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : Singleton<LevelMover>
{
    public float levelSpeed = 1f;
    public float spawnOffset = 700f;
    public Transform spawnPoint;
    public bool Moving = false;

    //DEBUG SPAWN
    public GameObject segmentPref;
    public void SpawnSegment()
    {
        Instantiate(segmentPref, spawnPoint);
    }

   
}
