using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePositioner : MonoBehaviour
{
    public Vector3 spawnLocation;
    public float speedOffset = 200f;
    // Start is called before the first frame update
    void Start()
    {
        //Randomize direction
        transform.eulerAngles = new Vector3(0, 90f * Random.Range(0, 4), 0);
        transform.localPosition += transform.forward*spawnLocation.z;
        transform.localPosition += -Vector3.up * speedOffset * LevelMover.instance.speedLevel;
    }

    
}
