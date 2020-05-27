﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelMover : Singleton<LevelMover>
{
    public static LevelMover instance;
    public static UnityEvent trailEvent = new UnityEvent();
    public static UnityEvent altmeterUpdateEvent = new UnityEvent();


    public GameObject playerBoundary;

    [Header("Speed Values")]
    public float startSpeed = 1f;
    public float maxSpeed = 1.5f;
    public float speedDecreaseRate = 0.1f;
    public float speedIncreaseRate = 0.2f;
    public int speedRate = 1;
    [SerializeField] private float levelSpeed = 1f;
    public float LevelSpeed
    {
        get
        {
            return levelSpeed;
        }

        set
        {
            levelSpeed = value;
            
            //Debug.Log("CHANGED");
        

            if (value == startSpeed)
            {
                speedRate = 1;
                TargetCam = "Speed";
            }
            else if (value > startSpeed && value <=(maxSpeed-startSpeed)/3f)
            {
                speedRate = 2;
                TargetCam = "Speed1";
            }
            else if (value > (maxSpeed-startSpeed)/3f && value <= maxSpeed)
            {
                speedRate = 3;
                TargetCam = "Speed2";
            }
            
            

        }
    }

    [SerializeField] private string targetCam = "";
    public string TargetCam
    {
        get
        {
            return targetCam;
        }

        set
        {
            if(value != targetCam && !ParachuteBool && !PreParachuteBool)
            {
                Debug.Log(value);
                InputCameraController.Instance.SetLiveCam(value);
                //toggle Trails if max speed or previous
                trailEvent.Invoke();
            }
            targetCam = value;

        }
    }



    public ContentSpawner contentSpawnerRef;

    public Transform groundHolder;
    public Transform groundTarget;
    public Transform noReturn;

    private float groundStartAltitude;

    public float altitudeRatio;


    public bool Moving = false;
    public bool PreParachuteBool = false;
    public bool ParachuteBool = false;
    public bool YellowZoneBool = false;
    public bool RedZoneBool = false;
    public Vector3 offsetDir;


    private PlayerMover playerMover;

   

    private void Awake()
    {
        instance = this;
       
    }


    private void Start()
    {
        playerMover = PlayerMover.Instance;

        groundStartAltitude = groundHolder.transform.position.y;

        FunctionHandler.OnRunningStateChange.AddListener(SetMovingBool);
        FunctionHandler.OnRunningStateChange.Invoke(false);
    }


   
    private void SetMovingBool(bool value)
    {
        Moving = value;

        //playerBoundary.SetActive(value);
        //contentSpawnerRef.gameObject.SetActive(value);
    }

    private void FixedUpdate()
    {
        if(Moving)
            UpdateHeight();

        if(levelSpeed != startSpeed)
        {
            levelSpeed -= speedDecreaseRate;
            LevelSpeed = Mathf.Clamp(levelSpeed, startSpeed, maxSpeed);
        }



        if(Input.GetMouseButtonDown(2))
        {
            DebugParachute();
        }

        offsetDir = playerMover.playerOffset;

    }

    


    public void UpdateHeight()
    {
        altitudeRatio = groundHolder.position.y/groundStartAltitude;
        
        altmeterUpdateEvent.Invoke();
    }

    public void SpeedIncrease()
    {
        levelSpeed += speedIncreaseRate;
        LevelSpeed = Mathf.Clamp(levelSpeed, startSpeed, maxSpeed);
    }

    public void SpeedDecrease()
    {
        levelSpeed -= speedIncreaseRate;
        LevelSpeed = Mathf.Clamp(levelSpeed, startSpeed, maxSpeed);
    }

    public void ResetSpeed()
    {
        levelSpeed = 0.5f;
        startSpeed = 0.5f;
    }



    public void StopMoving()
    {
        Debug.Log("REE");
        Moving = false;

        FunctionHandler.OnRunningStateChange.Invoke(false);

        InputCameraController.Instance.parachuteSlowCam.m_Follow.gameObject.SetActive(false);

        //groundHolder.position = new Vector3(0,PlayerMover.Instance.charachterTransform.position.y, 0);
        playerMover.charachterTransform.transform.position = Vector3.up * 0.5f;
    }




    public void DebugParachute()
    {
        groundHolder.position = new Vector3(groundHolder.position.x, -450, groundHolder.position.z);
        levelSpeed = maxSpeed;

    }
}
