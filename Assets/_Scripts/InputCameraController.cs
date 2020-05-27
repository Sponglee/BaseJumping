using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InputCameraController : Singleton<InputCameraController>
{

    public CinemachineVirtualCamera liveCam;
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
    public float cameraZoomRate = 10f;



    private void Start()
    {
        SetLiveCam("Start");
        ScoreSystem.ringSuccess.AddListener(ParachutePulled);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
           
        if(LevelMover.instance.Moving && !LevelMover.instance.ParachuteBool && !LevelMover.instance.PreParachuteBool)
        {


            if (Input.GetMouseButtonDown(0) )
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
     
        
    }

   
    public void SetLiveCam(string name)
    {
        Debug.Log("HERE " + name);
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

            case "ParachuteSpeed":
                liveCam = parachuteSpeedCam;
                break;
            case "ParachuteSlow":
                liveCam = parachuteSlowCam;
                break;
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


        Debug.Log(name);
    }


    public void SpeedUpCamAction()
    {
        if (!SpeedUpBool)
        {
            SpeedUpBool = true;
            SetLiveCam("Speed");


            SetLiveCam("Speed");
            SpeedUpBool = false;
            speedTimer = 0f;

            
        }
        else
            speedTimer = 0;
    }



    public void ParachutePulled()
    {
       
        
        SetLiveCam("ParachuteSpeed");
       


    }


    public IEnumerator StopParachuteZoom()
    {
        float lens = liveCam.m_Lens.FieldOfView;
        float zoom = liveCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance;
        while (liveCam != null && !LevelMover.instance.ParachuteBool)
        {
            lens += Time.deltaTime* cameraZoomRate;
            liveCam.m_Lens.FieldOfView = Mathf.Clamp(lens, 0,130);
            //liveCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = Mathf.Clamp(zoom-Time.deltaTime*cameraZoomRate,1,8);
            yield return new WaitForEndOfFrame();
        }
    }
}
