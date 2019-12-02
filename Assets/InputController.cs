using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InputController : MonoBehaviour
{
    //DEBUG
    public CinemachineVirtualCamera normalCam;
    public CinemachineVirtualCamera slowCam;
    public CinemachineVirtualCamera speedCam;

    public CinemachineVirtualCamera startCam;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            startCam.m_Priority = 0;
            LevelMover.Instance.Moving = true;
        }


        if(Input.GetMouseButton(0))
        {
            speedCam.m_Priority = 11;
            slowCam.m_Priority = 8;
            normalCam.m_Priority = 9;
        }
        else if(Input.GetMouseButton(1))
        {
            speedCam.m_Priority = 7;
            slowCam.m_Priority = 11;
            normalCam.m_Priority = 8;
        }
        else
        {
            speedCam.m_Priority = 7;
            slowCam.m_Priority = 8;
            normalCam.m_Priority = 10;

        }
    }
}
