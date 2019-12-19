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
                FunctionHandler.Instance.LevelComplete("LEVEL COMPLETE");
            }
            else
            {
                LevelMover.Instance.Moving = false;
                InputCameraController.Instance.SetLiveCam("Finish");
                GameManager.Instance.CollidedWithEarth();
                FunctionHandler.Instance.LevelComplete("GAME OVER");

            }


        }
    }
}
