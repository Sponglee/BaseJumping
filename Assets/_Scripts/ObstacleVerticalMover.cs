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
            transform.Translate((Vector3.up + LevelMover.instance.offsetDir) * LevelMover.instance.LevelSpeed*SpeedModifier);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boundary"))
        {
            Destroy(gameObject);

            //DEBUG SPAWN
            if(!LevelMover.instance.YellowZoneBool)
                LevelMover.instance.SpawnSegment();

            //Invoke spawn event in LevelMover._levelMover
        }
    }
}
