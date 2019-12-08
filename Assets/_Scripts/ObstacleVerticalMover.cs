using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVerticalMover : MonoBehaviour
{
    private LevelMover _levelMover;
    [SerializeField] private float speedModifier = 1f;
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
            transform.Translate((Vector3.up + _levelMover.offsetDir) * _levelMover.levelSpeed*speedModifier);
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
