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
                Debug.Log("REE");
                LevelMover.Instance.Moving = false;
                InputCameraController.Instance.SetLiveCam("Finish");
                InputCameraController.Instance.parachuteSlowCam.m_Follow.gameObject.SetActive(false);
                transform.parent.position = new Vector3(transform.parent.position.x, other.transform.position.y, transform.parent.position.z);
                //other.transform.position += Vector3.up * 0.5f;
                FunctionHandler.Instance.ResetPlayerPosition();

            }
            else
            {
                LevelMover.Instance.Moving = false;
                InputCameraController.Instance.SetLiveCam("Finish");
                GameManager.Instance.CollidedWithEarth();
            }
                FunctionHandler.Instance.ToggleCanvas("UI");
                FunctionHandler.Instance.ToggleCanvas("Menu");
        }
    }
}
