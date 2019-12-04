using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : Singleton<LevelMover>
{
    public float levelSpeed = 1f;
    public float spawnOffset = 700f;
    public float levelLayers = 15f;
    public Transform spawnPoint;
    public bool Moving = false;





    private void Start()
    {
        for (int i = 0; i < levelLayers; i++)
        {
            SpawnSegment(spawnOffset*i);
        }
       
    }



    //DEBUG SPAWN
    public GameObject[] segmentPrefs;
    public void SpawnSegment(float offset = 0f)
    {
        Instantiate(segmentPrefs[Random.Range(0,segmentPrefs.Length)], spawnPoint.position + Vector3.up*offset, Quaternion.identity,spawnPoint);
    }

   
}
