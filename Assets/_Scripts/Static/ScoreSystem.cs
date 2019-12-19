using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScorUpdateEvent : UnityEvent { };

public static class ScoreSystem 
{
    public static int playerScore = 0;
    public static int scoreMultiplier = 1;
   

    public static ScorUpdateEvent uiUpdateEvent = new ScorUpdateEvent();

    public static void IncreaseMultiplier()
    {
        scoreMultiplier++;
        uiUpdateEvent.Invoke();
    }

    public static void IncreaseScore()
    {
        playerScore++;
        uiUpdateEvent.Invoke();
    }

    public static void ResetMultiplier()
    {
        scoreMultiplier = 1;
    }
}
