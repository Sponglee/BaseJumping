using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierUI : ScoreUI
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem.uiUpdateEvent.AddListener(UpdateUI);
        targetText.text = "x";
    }

    public override void UpdateUI()
    {
        Debug.Log("UPDATE " + ScoreSystem.scoreMultiplier);
        if (ScoreSystem.scoreMultiplier != 1)
            targetText.enabled = true;

        targetText.text = string.Format("x{0}", ScoreSystem.scoreMultiplier.ToString());
    }
}
