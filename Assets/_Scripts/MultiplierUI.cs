﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierUI : ScoreUI
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem.uiUpdateEvent.AddListener(UpdateUI);
        ScoreSystem.multReset.AddListener(MultiplierFadeOut);
        ScoreSystem.ringSuccess.AddListener(RingSuccessFinished);

        targetText.text = "x";


    }

    public override void UpdateUI(int target)
    {
        if(target == 0)
        {
            Debug.Log("UPDATE " + ScoreSystem.ScoreMultiplier);
            if (ScoreSystem.ScoreMultiplier != 1)
            {

                targetText.enabled = true;
            }
            else
            {
                targetText.enabled = false;
               
            }
            targetText.text = string.Format("x{0}", ScoreSystem.ScoreMultiplier.ToString());
        }
        else if(target == 1)
        {
            targetText.text = string.Format("x{0}", ScoreSystem.ScoreMultiplier.ToString());
        }



       

    }

    public void MultiplierFadeOut()
    {
        GetComponent<Animator>().Play("FadeOut");
    }

    public void FadeOutFinished()
    {
        ScoreSystem.ResetMultiplier();
    }

    public void RingSuccess()
    {
        GetComponent<Animator>().Play("Success");
    }

    public void RingSuccessFinished()
    {
        ScoreSystem.EvaluateScores();
       
    }


}
