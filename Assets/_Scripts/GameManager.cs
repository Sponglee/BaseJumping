using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class GameManager : Singleton<GameManager>
{
    public GameObject fireWorksPref;
    public GameObject poofPref;

    public AltmeterBehaviour altmeter;
    

    // Start is called before the first frame update
    void Start()
    {
        GoalBehaviour.goalReached.AddListener(GoalTriggered);
        ParachuteTrigger.parachuteTriggerEvent.AddListener(ParachuteZone);
    }

   

    public void GoalTriggered(GoalBehaviour triggeredGoal)
    {
        Instantiate(fireWorksPref, triggeredGoal.transform.position, Quaternion.identity);
        Destroy(triggeredGoal.gameObject);
       
        LevelMover.Instance.SpeedIncrease();
    }

    public void CollidedWithEarth()
    {
        Instantiate(poofPref, Vector3.up, Quaternion.identity);
        Destroy(PlayerMover.Instance.gameObject);
    }

    public void ParachuteZone(bool RedZone)
    {
        if(RedZone)
        {
            altmeter.AlarmGlowToggle("Red", true);
            altmeter.AlarmGlowToggle("Yellow", false);
        }
        else
        {
            altmeter.AlarmGlowToggle("Yellow", true);

            //Debug.Log("TOO LATE");
            //FunctionHandler.Instance.PullRing();
        }
    }
}
