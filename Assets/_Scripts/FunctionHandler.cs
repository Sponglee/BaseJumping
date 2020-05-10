using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FunctionHandler : Singleton<FunctionHandler>
{
    public class LevelStartEvent : UnityEvent { }
    public static LevelStartEvent OnLevelStart = new LevelStartEvent();

    public Canvas ringCanvas;
    public Canvas uiCanvas;
    public Canvas menuCanvas;
    public Canvas levelCompleteCanvas;
    public Canvas scoreCompleteCanvas;

    public Text levelCompleteText;

    public Transform model;


    public GameObject playButton;
    public GameObject restartMenuButton;
    public GameObject resumeMenuButton;
    public GameObject parachuteSkipButton;

    public void ToggleCanvas(string targetName)
    {
        Canvas target;

        switch (targetName)
        {
            case "UI":
                target = uiCanvas;
                break;
            case "Ring":
                target = ringCanvas;
                break;
            case "Menu":
                target = menuCanvas;
                break;
            case "LevelComplete":
                target = levelCompleteCanvas;
                break;
            case "ScoreComplete":
                target = scoreCompleteCanvas;
                break;
            default:
                return;
        }

        target.gameObject.SetActive(!target.gameObject.activeSelf);
        //uiCanvas.gameObject.SetActive(false);
    }


  

    public void StartLevel()
    {
        ToggleCanvas("Menu");
        ToggleCanvas("UI");

        OnLevelStart.Invoke();

        InputCameraController.Instance.SetLiveCam("Speed");
        LevelMover.Instance.Moving = true;
        //model.localEulerAngles = new Vector3(90f, 90f, 0f);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void ResetPlayerRotation()
    {
        Vector3 tmpPos = PlayerMover.Instance.model.position;

        PlayerMover.Instance.model.localEulerAngles = new Vector3(-90f,0,0);
        PlayerMover.Instance.model.position = new Vector3(tmpPos.x, 0f, tmpPos.z);
    }


    public void LevelComplete(string text)
    {
        levelCompleteText.text = text;

       
        Instance.ToggleCanvas("UI");
        Instance.ToggleCanvas("LevelComplete");

        restartMenuButton.SetActive(true);
        resumeMenuButton.SetActive(false);


        ScoreComplete();
    }

    public void ScoreComplete()
    {
        Instance.ToggleCanvas("ScoreComplete");
        ScoreSystem.scoreComplete.Invoke();
        StartCoroutine(ScoreSystem.StopEvaluateScore());
    }
   

    public void SkipToggle()
    {
        parachuteSkipButton.SetActive(!parachuteSkipButton.activeSelf);
    }

    public void ParachuteSkip()
    {
        LevelMover.Instance.StopMoving();
    }
}
