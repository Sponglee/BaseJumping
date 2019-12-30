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
                LevelMover.Instance.ParachuteBool = false;
                GameManager.Instance.SpawnPoof(Vector3.up);
                GameManager.Instance.SpawnFireWork(other.transform.position + Vector3.up*2f);

                InputCameraController.Instance.SetLiveCam("Finish");
                FunctionHandler.Instance.LevelComplete("LEVEL COMPLETE");

                GameManager.Instance.SpawnEndFireWork();
            }
            else
            {
                LevelMover.Instance.Moving = false;
                LevelMover.Instance.ParachuteBool = false;
                GameManager.Instance.SpawnPoof(Vector3.up);
                ScoreSystem.ResetMultiplier();
                Destroy(PlayerMover.Instance.gameObject);
                
                InputCameraController.Instance.SetLiveCam("Normal");
                FunctionHandler.Instance.LevelComplete("GAME OVER");


            }

            
        }
    }
}
