using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteTrigger : MonoBehaviour
{

    [SerializeField]  private ObstacleVerticalMover ground;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("RE");
            //DEBUG 
            ground.enabled = true;
            FunctionHandler.Instance.RingCanvasEnabled();
            //InputCameraController.Instance.SetLiveCam("Parachute");
        }
    }



}
