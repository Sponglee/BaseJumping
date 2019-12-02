using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private LevelMover _levelMover;

    // Start is called before the first frame update
    void Start()
    {
        _levelMover = LevelMover.Instance;   
    }

    // Update is called once per frame
    void Update()
    {
        if(_levelMover.Moving)
        {
            transform.Translate(Vector3.up * _levelMover.levelSpeed);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boundary"))
        {
            Destroy(gameObject);

            //DEBUG SPAWN
            _levelMover.SpawnSegment();

            //Invoke spawn event in _levelMover
        }
    }
}
