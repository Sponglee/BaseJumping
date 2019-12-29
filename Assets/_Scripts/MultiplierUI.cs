using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierUI : ScoreUI
{
    //Update ui even (0 - multiplier, 1 - score)
    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem.uiUpdateEvent.AddListener(UpdateUI);
        ScoreSystem.multReset.AddListener(MultiplierFadeOut);
       
        targetText.text = "";


    }

    public override void UpdateUI(int target)
    {
        if(target == 0)
        {
            //Debug.Log("UPDATE " + ScoreSystem.ScoreMultiplier);
            if (ScoreSystem.ScoreMultiplier > 1)
            {

                targetText.enabled = true;
                targetText.text = string.Format("x{0}", ScoreSystem.ScoreMultiplier.ToString());
            }
            else
            {
                targetText.enabled = false;
                
            }
            
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

  


}
