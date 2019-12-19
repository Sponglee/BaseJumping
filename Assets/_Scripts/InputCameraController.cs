using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InputCameraController : Singleton<InputCameraController>
{

    [SerializeField] private CinemachineVirtualCamera liveCam;
    [Header("")]

    //DEBUG
    public CinemachineVirtualCamera normalCam;
  
    public CinemachineVirtualCamera speedCam;
    public CinemachineVirtualCamera speedCam1;
    public CinemachineVirtualCamera speedCam2;


    public CinemachineVirtualCamera startCam;
    public CinemachineVirtualCamera finishCam;


    public CinemachineVirtualCamera parachuteSpeedCam;
    public CinemachineVirtualCamera parachuteSlowCam;

    public Transform model;

    [Header("Speed Control")]
    public bool SpeedUpBool = false;
    public float speedTimer = 0;
    public float speedUpTime = 5f;

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
                SetLiveCam("Normal");
                //model.localEulerAngles = new Vector3(140f, 0f, 0f);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                SetLiveCam("Slow");
                //model.localEulerAngles = new Vector3(80f, 0f, 0f);
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
       
        switch (name)
        {
            case "Speed":
                {

                    liveCam = speedCam;
                }
                break;
            case "Speed1":
                {

                    liveCam = speedCam1;
                }
                break;
            case "Speed2":
                {

                    liveCam = speedCam2;
                }
                break;
            case "Start":
                {

                    liveCam = startCam;
                }
                break;
            case "Normal":
                liveCam = normalCam;
                break;
         
            //case "Parachute":
            //    targetCam = parachuteSpeedCam;
                //break;
            case "Finish":
                liveCam = finishCam;
                break;
            default:
                //liveCam = null;
                break;
        }

        if(liveCam != null)
        {
            foreach (var cam in GameObject.FindGameObjectsWithTag("Vcam"))
            {
                cam.GetComponent<CinemachineVirtualCamera>().m_Priority = 1;
            }
            liveCam.m_Priority = 99;
        }
    }


    public void SpeedUpCamAction()
    {
        if (!SpeedUpBool)
        {
            SpeedUpBool = true;
            SetLiveCam("Speed");


            SetLiveCam("Normal");
            SpeedUpBool = false;
            speedTimer = 0f;

            LevelMover.Instance.ResetSpeed();
        }
        else
            speedTimer = 0;
    }



    public void ParachutePulled()
    {
        parachuteSpeedCam.m_Follow.gameObject.SetActive(true);
        speedCam = parachuteSpeedCam;
        normalCam = parachuteSpeedCam;
        SetLiveCam("Start");
        //DEBUG
        LevelMover.Instance.ParachuteBool = true;


    }

}
