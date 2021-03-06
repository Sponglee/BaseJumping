﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVerticalMover : MonoBehaviour
{


    //private LevelMover LevelMover._levelMover;
    [SerializeField] private float speedModifier = 1f;
    public float SpeedModifier
    {
        get
        {
            return speedModifier;
        }

        set
        {
            speedModifier = value;
        }
    }

   

    // Update is called once per frame
    void FixedUpdate()
    {
        if(LevelMover.instance.Moving)
        {
            transform.Translate(Vector3.up * LevelMover.instance.LevelSpeed * SpeedModifier + LevelMover.instance.offsetDir);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boundary"))
        {
            Destroy(gameObject);

            //DEBUG SPAWN
            if (!LevelMover.instance.YellowZoneBool && transform.CompareTag("Cloud"))
                LevelMover.instance.contentSpawnerRef.SpawnClouds();
            else if (!LevelMover.instance.YellowZoneBool && transform.CompareTag("Goal"))
                LevelMover.instance.contentSpawnerRef.SpawnGoal();
            //Invoke spawn event in LevelMover._levelMover
        }
    }
}
