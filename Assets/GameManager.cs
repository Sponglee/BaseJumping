using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class GameManager : MonoBehaviour
{
    public GameObject fireWorksPref;


    

    // Start is called before the first frame update
    void Start()
    {
        GoalBehaviour.goalReached.AddListener(GoalTriggered);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GoalTriggered(GoalBehaviour triggeredGoal)
    {
        Instantiate(fireWorksPref, triggeredGoal.transform.position, Quaternion.identity);
        Destroy(triggeredGoal.gameObject);
       
        LevelMover.Instance.SpeedIncrease();
    }
}
