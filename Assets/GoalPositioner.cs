using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPositioner : MonoBehaviour
{

    [SerializeField] private  float spreadRadius = 100f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-spreadRadius, spreadRadius), transform.position.y, Random.Range(-spreadRadius, spreadRadius));
    }

}
