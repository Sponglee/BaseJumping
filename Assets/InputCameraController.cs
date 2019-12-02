using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InputCameraController : MonoBehaviour
{
    //DEBUG
    public CinemachineVirtualCamera normalCam;
    public CinemachineVirtualCamera slowCam;
    public CinemachineVirtualCamera speedCam;
    public CinemachineVirtualCamera startCam;


    public Transform model;
   
    // Update is called once per frame
    void Update()
    {
           
        if(LevelMover.Instance.Moving)
        {


            if (Input.GetMouseButton(0))
            {
                speedCam.m_Priority = 11;
                slowCam.m_Priority = 8;
                normalCam.m_Priority = 9;
                model.localEulerAngles = new Vector3(140f, 90f, 0f);
            }
            else if (Input.GetMouseButton(1))
            {
                speedCam.m_Priority = 7;
                slowCam.m_Priority = 11;
                normalCam.m_Priority = 8;
                model.localEulerAngles = new Vector3(80f, 90f, 0f);
            }
            else
            {
                speedCam.m_Priority = 7;
                slowCam.m_Priority = 8;
                normalCam.m_Priority = 10;
                model.localEulerAngles = new Vector3(90f, 90f, 0f);

            }
        }
        else
        {
            if (Input.GetMouseButtonDown(2))
            {
                startCam.m_Priority = 0;
                LevelMover.Instance.Moving = true;
                model.localEulerAngles = new Vector3(90f, 90f, 0f);
            }
        }
        
    }
}
