using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionHandler : Singleton<FunctionHandler>
{
    public Canvas RingCanvas;
    public Canvas uiCanvas;
    public Transform model;
    public GameObject playButton;

    public void RingCanvasEnabled()
    {
        RingCanvas.gameObject.SetActive(true);
        //uiCanvas.gameObject.SetActive(false);
    }


    public void PullRing()
    {
        
       

        RingCanvas.gameObject.SetActive(false);
        //uiCanvas.gameObject.SetActive(true);
        ResetPlayerPosition();
        InputCameraController.Instance.ParachutePulled();
        LevelMover.Instance.ResetSpeed();
    }


    public void StartLevel()
    {
        playButton.SetActive(false);
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

}
