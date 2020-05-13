using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class TriggerEvent : UnityEvent<GoalBehaviour> { };

public class GoalBehaviour : MonoBehaviour
{

    public static TriggerEvent goalReached = new TriggerEvent();
    [SerializeField] private  float spreadRadius = 100f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(Random.Range(-spreadRadius, spreadRadius), transform.position.y, Random.Range(-spreadRadius, spreadRadius));
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            goalReached.Invoke(this);
        }
    }

}
