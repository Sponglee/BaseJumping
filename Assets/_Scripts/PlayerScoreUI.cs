using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreUI : ScoreUI
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem.uiUpdateEvent.AddListener(UpdateUI);
        targetText.text = ScoreSystem.playerScore.ToString();
    }

    public override void UpdateUI()
    {
        targetText.text = ScoreSystem.playerScore.ToString();
    }
}
