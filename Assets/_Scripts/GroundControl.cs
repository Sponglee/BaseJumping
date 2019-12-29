using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (LevelMover.Instance.ParachuteBool)
            {
                LevelMover.Instance.ResetPosition();
                InputCameraController.Instance.SetLiveCam("Finish");
                FunctionHandler.Instance.LevelComplete("LEVEL COMPLETE");
                GameManager.Instance.CollidedWithEarth();
            }
            else
            {
                LevelMover.Instance.Moving = false;
                
                GameManager.Instance.CollidedWithEarth();
                Destroy(PlayerMover.Instance.gameObject);
                ScoreSystem.ResetMultiplier();
                InputCameraController.Instance.SetLiveCam("Normal");
                FunctionHandler.Instance.LevelComplete("GAME OVER");


            }


        }
    }
}
