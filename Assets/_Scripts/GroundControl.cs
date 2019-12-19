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

            }
            else
            {
                LevelMover.Instance.Moving = false;
                InputCameraController.Instance.SetLiveCam("Finish");
                GameManager.Instance.CollidedWithEarth();
            }

                FunctionHandler.Instance.LevelComplete();

        }
    }
}
