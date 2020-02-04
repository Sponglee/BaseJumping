using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelMover : Singleton<LevelMover>
{
    public static LevelMover instance;

    public static UnityEvent trailEvent = new UnityEvent();
    public static UnityEvent altmeterUpdateEvent = new UnityEvent();

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



   

    private void Awake()
    {
        instance = Instance;
    }


    private void Start()
    {
        

        groundStartAltitude = groundHolder.transform.position.y;
       
       
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

        InputCameraController.Instance.parachuteSlowCam.m_Follow.gameObject.SetActive(false);
        
        //groundHolder.position = new Vector3(0,PlayerMover.Instance.charachterTransform.position.y, 0);
        //other.transform.position += Vector3.up * 0.5f;
    }




    public void DebugParachute()
    {
        groundHolder.position = new Vector3(groundHolder.position.x, GameObject.Find("1YellowZoneBoundary").transform.position.y, groundHolder.position.z);
        levelSpeed = maxSpeed;

    }
}
