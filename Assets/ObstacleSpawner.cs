using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public Transform obstacleHolder;
    public GameObject[] obstacles;

    public float speedOffset = 200f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            GameObject tmpObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform);
            tmpObstacle.transform.position += -Vector3.up * speedOffset * LevelMover.instance.speedLevel;
        }
    }
}
