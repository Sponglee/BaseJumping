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
        transform.GetChild(0).eulerAngles = new Vector3(0, 90f * Random.Range(0, 4), 0);
        transform.GetChild(0).localPosition += transform.GetChild(0).forward*spawnLocation.z;
        transform.GetChild(0).localPosition += -Vector3.up * speedOffset * LevelMover.instance.speedRate;
    }

    
}
