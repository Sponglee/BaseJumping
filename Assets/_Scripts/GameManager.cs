using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class GameManager : Singleton<GameManager>
{
    public GameObject fireWorksPref;
    public GameObject poofPref;

    public AltmeterBehaviour altmeter;

    public float multiplierCoolDown = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        GoalBehaviour.goalReached.AddListener(GoalTriggered);
        ParachuteTrigger.parachuteTriggerEvent.AddListener(ParachuteZone);

        ScoreSystem.ResetScores();
       
    }

   

    public void GoalTriggered(GoalBehaviour triggeredGoal)
    {
        Instantiate(fireWorksPref, triggeredGoal.transform.position, Quaternion.identity);
        Destroy(triggeredGoal.gameObject);
       
        LevelMover.Instance.SpeedIncrease();

        ScoreSystem.IncreaseScore();
    }

    public void CollidedWithEarth()
    {
        Instantiate(poofPref, Vector3.up, Quaternion.identity);
        Destroy(PlayerMover.Instance.gameObject);

        ScoreSystem.ResetMultiplier();
    }

    public void ParachuteZone(bool RedZone)
    {
        if(!RedZone)
        {
            altmeter.AlarmGlowToggle("Yellow", true);
            StartCoroutine(StopMultiplier());
            StartCoroutine(InputCameraController.Instance.StopParachuteZoom());
        }
        else
        {
            StopCoroutine(GameManager.Instance.StopMultiplier());

            ScoreSystem.multReset.Invoke();


           

            altmeter.AlarmGlowToggle("Red", true);
            altmeter.AlarmGlowToggle("Yellow", false);

            //Debug.Log("TOO LATE");
            //FunctionHandler.Instance.PullRing();
        }
    }


    public IEnumerator StopMultiplier()
    {
        while (LevelMover.instance.YellowZoneBool)
        {
            ScoreSystem.IncreaseMultiplier();
            
            yield return new WaitForSeconds(multiplierCoolDown);
        }
    }

   
}
