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

[System.Serializable]
public class ScoreCompleteEvent : UnityEvent { };

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
    public static float multiplierCoolDown = 0.2f;

    //Update ui even (0 - multiplier, 1 - score)
    public static ScorUpdateEvent uiUpdateEvent = new ScorUpdateEvent();
    //For reset animation playback
    public static MultiplierResetEvent multReset = new MultiplierResetEvent();
    //For successfull ring pull 
    public static RingSuccessEvent ringSuccess = new RingSuccessEvent();
    //For successfull ring pull 
    public static ScoreCompleteEvent scoreComplete = new ScoreCompleteEvent();


    public static void DecreaseMultiplier()
    {
        ScoreMultiplier--;

    }


    public static void IncreaseMultiplier()
    {
        ScoreMultiplier++;
       
    }

    public static void IncreaseScore(int scoreAmount = 1)
    {
        PlayerScore+= scoreAmount;
        
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

   


    public static IEnumerator StopMultiplier()
    {
        while (!LevelMover.instance.ParachuteBool)
        {
            if(LevelMover.instance.Moving)
                IncreaseMultiplier();

            yield return new WaitForSeconds(multiplierCoolDown);
        }
    }


    public static IEnumerator StopEvaluateScore()
    {
        int scoreToEvaluate = playerScore;
        float tmpMultiplier = multiplierCoolDown;

        while (ScoreMultiplier>1)
        {
            IncreaseScore(scoreToEvaluate);
            DecreaseMultiplier();
            tmpMultiplier -= 0.01f;
            yield return new WaitForSeconds(tmpMultiplier);
        }

    }

}
