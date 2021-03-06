﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentSpawner : Singleton<ContentSpawner>
{
   
    public int lastLayerIndex= 0;
    public int lastCloudIndex = 0;

    public float cloudsOffset = 700f;
    public float layerOffset = 200f;

    public float cloudsCount = 15f;

    public Transform cloudsHolder;
    public Transform layersHolder;

    //Level content prefabs
    public GameObject goalPrefab;
    public GameObject[] obstaclePrefabs;

    //Cloud Layer Prefabs
    public GameObject[] cloudsPref;




    // Start is called before the first frame update
    void Start()
    {
        



        for (int i = 0; i < cloudsCount; i++)
        {
            SpawnClouds();
            SpawnGoal();
        }

    }




    public void SpawnGoalLayer()
    {
        Debug.Log(lastLayerIndex);
        Debug.Log(" ==== " + (layersHolder.position - Vector3.up * lastLayerIndex * layerOffset));
       Instantiate(goalPrefab, layersHolder.position - Vector3.up * lastLayerIndex*layerOffset, Quaternion.identity, layersHolder);
    }

    public void SpawnCloudLayer()
    {
        Instantiate(cloudsPref[Random.Range(0, cloudsPref.Length)], cloudsHolder.position - Vector3.up * lastCloudIndex*cloudsOffset, Quaternion.identity, cloudsHolder);
    }



    public void SpawnClouds()
    {
        SpawnCloudLayer();
        lastCloudIndex++;
    }

    public void SpawnGoal(GoalBehaviour target=null)
    {
        SpawnGoalLayer();
        lastLayerIndex++;
    }
}
