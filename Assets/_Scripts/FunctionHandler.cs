using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FunctionHandler : Singleton<FunctionHandler>
{
    public Canvas ringCanvas;
    public Canvas uiCanvas;
    public Canvas menuCanvas;
    public Canvas levelCompleteCanvas;

    public Text levelCompleteText;

    public Transform model;


    public GameObject playButton;
    public GameObject restartMenuButton;
    public GameObject resumeMenuButton;

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
            default:
                return;
        }

        target.gameObject.SetActive(!target.gameObject.activeSelf);
        //uiCanvas.gameObject.SetActive(false);
    }


    public void PullRing()
    {
        ringCanvas.gameObject.SetActive(false);
        //uiCanvas.gameObject.SetActive(true);
        ResetPlayerPosition();
        InputCameraController.Instance.ParachutePulled();
        LevelMover.Instance.ResetSpeed();
        GameManager.Instance.StopAllCoroutines();

        ScoreSystem.ringSuccess.Invoke();
    }


    public void StartLevel()
    {
        ToggleCanvas("Menu");
        ToggleCanvas("UI");

        InputCameraController.Instance.SetLiveCam("Speed");
        LevelMover.Instance.Moving = true;
        //model.localEulerAngles = new Vector3(90f, 90f, 0f);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void ResetPlayerPosition()
    {
        model.localEulerAngles = new Vector3(-90f,transform.eulerAngles.y,0);
    }


    public void LevelComplete(string text)
    {
        levelCompleteText.text = text;

        Instance.ToggleCanvas("UI");
        Instance.ToggleCanvas("LevelComplete");
        restartMenuButton.SetActive(true);
        resumeMenuButton.SetActive(false);
    }


   
}
