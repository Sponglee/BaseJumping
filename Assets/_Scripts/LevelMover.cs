using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMover : Singleton<LevelMover>
{
    [Header("Speed Values")]
    public float startSpeed = 1f;
    public float maxSpeed = 1.5f;
    public float speedDecreaseRate = 0.1f;
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
            
            Debug.Log("CHANGED");
        
            if (value == startSpeed)
                TargetCam = "Speed";
            else if (value > startSpeed && value <= 1.1f)
                TargetCam = "Speed1";
            else if (value > 1.1f && value <= maxSpeed)
                TargetCam = "Speed2";
            
            

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
            targetCam = value;
            InputCameraController.Instance.SetLiveCam(TargetCam);
        }
    }


    public float spawnOffset = 700f;
    public float levelLayers = 15f;


    public Transform spawnPoint;
    public Transform groundHolder;
    public Transform groundTarget;

    private float groundStartAltitude;

    public Slider altmeter;

    public bool Moving = false;
    public bool ParachuteBool = false;
    public Vector3 offsetDir;



    private void Start()
    {
        groundStartAltitude = groundHolder.transform.position.y;
        for (int i = 0; i < levelLayers; i++)
        {
            SpawnSegment(spawnOffset*i);
        }
       
    }

    private void FixedUpdate()
    {
        if(Moving)
            UpdateAltmeter();

        if(levelSpeed != startSpeed)
        {
            levelSpeed -= speedDecreaseRate;
            LevelSpeed = Mathf.Clamp(levelSpeed, startSpeed, maxSpeed);
        }
    }

    //DEBUG SPAWN
    public GameObject[] segmentPrefs;


    public void SpawnSegment(float offset = 0f)
    {
        Instantiate(segmentPrefs[Random.Range(0,segmentPrefs.Length)], spawnPoint.position + Vector3.up*offset, Quaternion.identity,spawnPoint);
    }

    public void UpdateAltmeter()
    {
        altmeter.value = groundHolder.position.y/groundStartAltitude;
    }

    public void SpeedIncrease()
    {
        levelSpeed += 0.2f;
        LevelSpeed = Mathf.Clamp(levelSpeed, startSpeed, maxSpeed);
    }

    public void ResetSpeed()
    {
        levelSpeed = 1f;
    }
}
