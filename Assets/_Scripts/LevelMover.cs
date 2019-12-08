using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMover : Singleton<LevelMover>
{
    public float levelSpeed = 1f;
    public float spawnOffset = 700f;
    public float levelLayers = 15f;


    public Transform spawnPoint;
    public Transform groundHolder;

    public Slider altmeter;
    public float groundSpeedModifier;

    public bool Moving = false;

    public Vector3 offsetDir;



    private void Start()
    {
        groundSpeedModifier = groundHolder.GetComponent<ObstacleVerticalMover>().SpeedModifier;
        for (int i = 0; i < levelLayers; i++)
        {
            SpawnSegment(spawnOffset*i);
        }
       
    }

    private void Update()
    {
        if(Moving)
            UpdateAltmeter(groundSpeedModifier*levelSpeed);
    }

    //DEBUG SPAWN
    public GameObject[] segmentPrefs;
    public void SpawnSegment(float offset = 0f)
    {
        Instantiate(segmentPrefs[Random.Range(0,segmentPrefs.Length)], spawnPoint.position + Vector3.up*offset, Quaternion.identity,spawnPoint);
    }

    public void UpdateAltmeter(float groundSpeed)
    {
        altmeter.value += groundSpeed / groundHolder.position.y;
    }
}
