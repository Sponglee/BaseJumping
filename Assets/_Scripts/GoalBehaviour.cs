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
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            goalReached.Invoke(this);
        }
    }

}
