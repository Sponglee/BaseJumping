using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public Transform obstacleHolder;
    public GameObject[] obstacles;

  
    public float spawnTime = 10f;

    

    private void Start()
    {
        //StartCoroutine(StopSpawnObstacle());
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            SpawnObstacle();
        }
    }


    public IEnumerator StopSpawnObstacle()
    {
        while (!LevelMover.instance.YellowZoneBool)
        {
            if(LevelMover.instance.Moving)
            {
                Debug.Log("SPAWNED");
                SpawnObstacle();
                yield return new WaitForSeconds(spawnTime);
            }
            yield return null;
        }
    }


    public void SpawnObstacle()
    {
        GameObject tmpObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform);

    }
}
