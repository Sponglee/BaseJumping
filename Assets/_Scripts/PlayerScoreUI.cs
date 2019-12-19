using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreUI : ScoreUI
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem.uiUpdateEvent.AddListener(UpdateUI);
        targetText.text = ScoreSystem.PlayerScore.ToString();
    }

    public override void UpdateUI(int target)
    {
        targetText.text = ScoreSystem.PlayerScore.ToString();
    }
}
