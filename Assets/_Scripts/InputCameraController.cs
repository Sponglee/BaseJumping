using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InputCameraController : Singleton<InputCameraController>
{
    //DEBUG
    public CinemachineVirtualCamera normalCam;
    public CinemachineVirtualCamera slowCam;
    public CinemachineVirtualCamera speedCam;
    public CinemachineVirtualCamera startCam;
    public CinemachineVirtualCamera finishCam;
    public CinemachineVirtualCamera parachuteSpeedCam;
    public CinemachineVirtualCamera parachuteSlowCam;

    public Transform model;


    private void Start()
    {
        SetLiveCam("Start");
    }

    // Update is called once per frame
    void Update()
    {
           
        if(LevelMover.Instance.Moving)
        {


            if (Input.GetMouseButtonDown(0))
            {
                SetLiveCam("Speed");
                model.localEulerAngles = new Vector3(140f, 90f, 0f);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                SetLiveCam("Slow");
                model.localEulerAngles = new Vector3(80f, 90f, 0f);
            }
            //else
            //{
            //    speedCam.m_Priority = 7;
            //    slowCam.m_Priority = 8;
            //    normalCam.m_Priority = 10;
            //    model.localEulerAngles = new Vector3(90f, 90f, 0f);

            //}
        }
        else
        {
            if (Input.GetMouseButtonDown(2))
            {
              
            }
        }
        
    }



    public void SetLiveCam(string name)
    {
        CinemachineVirtualCamera targetCam;
        switch (name)
        {
            case "Speed":
                    targetCam = speedCam;
                break;
            case "Slow":
                targetCam = slowCam;
                break;
            //case "Parachute":
            //    targetCam = parachuteSpeedCam;
                //break;
            case "Finish":
                targetCam = finishCam;
                break;
            default:
                targetCam = null;
                break;
        }

        if(targetCam != null)
        {
            foreach (var cam in GameObject.FindGameObjectsWithTag("Vcam"))
            {
                cam.GetComponent<CinemachineVirtualCamera>().m_Priority = 1;
            }
            targetCam.m_Priority = 99;
        }
    }

}
