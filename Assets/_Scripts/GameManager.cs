using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class GameManager : Singleton<GameManager>
{
    public GameObject fireWorksPref;
    public GameObject poofPref;
    public GameObject endFireWorksPref;

    public AltmeterBehaviour altmeter;

    
    // Start is called before the first frame update
    void Start()
    {
        GoalBehaviour.goalReached.AddListener(GoalTriggered);
        ParachuteTrigger.parachuteTriggerEvent.AddListener(ParachuteZone);

        ScoreSystem.ResetScores();
       
    }

   

    public void GoalTriggered(GoalBehaviour triggeredGoal)
    {
        SpawnFireWork(PlayerMover.Instance.charachterTransform.position - Vector3.up * 10f);

        Destroy(triggeredGoal.gameObject);
       
        LevelMover.Instance.SpeedIncrease();

        ScoreSystem.IncreaseScore();
    }




    

    public void ParachuteZone(bool RedZone)
    {
        if(!RedZone)
        {
            altmeter.AlarmGlowToggle("Yellow", true);
            StartCoroutine(ScoreSystem.StopMultiplier());
            //StartCoroutine(InputCameraController.Instance.StopParachuteZoom());
        }
        else
        {
            //StopCoroutine(GameManager.Instance.StopMultiplier());

            //ScoreSystem.multReset.Invoke();


           

            altmeter.AlarmGlowToggle("Red", true);
            altmeter.AlarmGlowToggle("Yellow", false);

            //Debug.Log("TOO LATE");
            //FunctionHandler.Instance.PullRing();
        }
    }


    public void SpawnFireWork(Vector3 target)
    {
        Instantiate(fireWorksPref, target, Quaternion.identity);
    }

    public void SpawnPoof(Vector3 target)
    {

        Instantiate(poofPref, target, Quaternion.identity);

    }

    public void SpawnEndFireWork()
    {
        Instantiate(endFireWorksPref, InputCameraController.Instance.liveCam.transform);
    }


    public void GameOver()
    {
        LevelMover.Instance.Moving = false;
        LevelMover.Instance.ParachuteBool = false;
        Instance.SpawnPoof(Vector3.up);
        ScoreSystem.ResetMultiplier();
        Destroy(PlayerMover.Instance.gameObject);

        InputCameraController.Instance.SetLiveCam("Normal");
        FunctionHandler.Instance.LevelComplete("GAME OVER");
    }


     public void GameWin(Transform other)
    {
        LevelMover.Instance.ResetPosition();
        LevelMover.Instance.ParachuteBool = false;
        GameManager.Instance.SpawnPoof(Vector3.up);
        GameManager.Instance.SpawnFireWork(other.position + Vector3.up * 2f);

        InputCameraController.Instance.SetLiveCam("Finish");
        FunctionHandler.Instance.LevelComplete("LEVEL COMPLETE");

        GameManager.Instance.SpawnEndFireWork();
    }


}
