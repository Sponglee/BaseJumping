using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScorUpdateEvent : UnityEvent<int> { };
[System.Serializable]
public class MultiplierResetEvent : UnityEvent { };
[System.Serializable]
public class RingSuccessEvent : UnityEvent { };


public static class ScoreSystem 
{
    private static int playerScore = 0;
    public static int PlayerScore
    {
        get
        {
            return playerScore;
        }

        set
        {
            playerScore = value;
            uiUpdateEvent.Invoke(1);
        }
    }

    public static int ScoreMultiplier
    {
        get
        {
            return scoreMultiplier;
        }

        set
        {
            scoreMultiplier = value;
            uiUpdateEvent.Invoke(0);
        }
    }

    private static int scoreMultiplier = 1;

    //Update ui even (0 - multiplier, 1 - score)
    public static ScorUpdateEvent uiUpdateEvent = new ScorUpdateEvent();
    //For reset animation playback
    public static MultiplierResetEvent multReset = new MultiplierResetEvent();
    //For successfull ring pull 
    public static RingSuccessEvent ringSuccess = new RingSuccessEvent();


    public static void IncreaseMultiplier()
    {
        ScoreMultiplier++;
       
    }

    public static void IncreaseScore()
    {
        PlayerScore++;
        
    }

    public static void ResetMultiplier()
    {
        ScoreMultiplier = 1;
    }

    public static void ResetScores()
    {
        PlayerScore = 0;
        ResetMultiplier();
    }

    public static void EvaluateScores()
    {
        //Make count score sequence ( for i<multiple => playerScore + playerScore each frame)
    }

}
