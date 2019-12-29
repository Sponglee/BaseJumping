﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RingPuller : MonoBehaviour
{

    //Update ui even (0 - multiplier, 1 - score)
    public static UnityEvent ringPullSpeedUp = new UnityEvent();



    [SerializeField] private Joystick ring;
    [SerializeField] private float parachutePullTime = 5f;
    [SerializeField] private float parachuteTimer = 0f;
    [SerializeField] private float speedUpRate = 0.1f;

    public float ParachuteTimer
    {
        get
        {
            return parachuteTimer;
        }

        set
        {
            parachuteTimer = value;
            parachutePullSlider.fillAmount = parachuteTimer / parachutePullTime;
            if (parachutePullSlider.fillAmount == 1)
            {
                parachutePullSlider.gameObject.SetActive(false);
            }
        }
    }

    public Image parachutePullSlider;

    private void Start()
    {

        ScoreSystem.ringSuccess.AddListener(RingPulledSequence);
        ringPullSpeedUp.AddListener(RingPullSpeedUp);

    }


    private void Update()
    {
        //Debug.Log(ring.Vertical);
        if(ring.gameObject.activeSelf && ring.Vertical <=-1)
        {
            PullRing();
        }


    }

    public void PullRing()
    {

        //uiCanvas.gameObject.SetActive(true);
        //FunctionHandler.Instance.ResetPlayerPosition();
        //LevelMover.Instance.ResetSpeed();

        LevelMover.Instance.PreParachuteBool = true;

        GameManager.Instance.StopAllCoroutines();


        ScoreSystem.ringSuccess.Invoke();

    }

    public void RingPulledSequence()
    {
        ring.gameObject.SetActive(false);

        PlayerMover.Instance.preParachuteHolder.gameObject.SetActive(true);
        StartCoroutine(StopRingPulled());
    }
   

    //Fill the slider to get parachute out
    private IEnumerator StopRingPulled()
    {
        
        while(ParachuteTimer < parachutePullTime)
        {
            ParachuteTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();

        }

        if(PlayerMover.Instance != null)
        {
            PlayerMover.Instance.preParachuteHolder.gameObject.SetActive(false);
            PlayerMover.Instance.parachuteHolder.gameObject.SetActive(true);
            
            LevelMover.instance.ParachuteBool = true;
            LevelMover.Instance.ResetSpeed();
            InputCameraController.Instance.SetLiveCam("ParachuteSlow");
            FunctionHandler.Instance.ResetPlayerPosition();
        }
       
    }

    public void RingPullSpeedUp()
    {
        ParachuteTimer += speedUpRate;
        Debug.Log("SPEEDUP");
    }
    

}
