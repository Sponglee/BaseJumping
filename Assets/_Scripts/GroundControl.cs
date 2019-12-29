using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Landed with parachute opened
            if (LevelMover.Instance.ParachuteBool)
            {
                LevelMover.Instance.ResetPosition();
                InputCameraController.Instance.SetLiveCam("Finish");
                FunctionHandler.Instance.LevelComplete("LEVEL COMPLETE");
                GameManager.Instance.CollidedWithEarth();
                LevelMover.Instance.ParachuteBool = false;
            }
            else
            {
                LevelMover.Instance.Moving = false;
                LevelMover.Instance.ParachuteBool = false;
                GameManager.Instance.CollidedWithEarth();
                Destroy(PlayerMover.Instance.gameObject);
                ScoreSystem.ResetMultiplier();
                
                InputCameraController.Instance.SetLiveCam("Normal");
                FunctionHandler.Instance.LevelComplete("GAME OVER");


            }


        }
    }
}
