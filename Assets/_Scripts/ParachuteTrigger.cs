using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ParachuteEvent : UnityEvent<bool> { };

public class ParachuteTrigger : MonoBehaviour
{

    public static ParachuteEvent parachuteTriggerEvent = new ParachuteEvent();


    [SerializeField]  private ObstacleVerticalMover ground;
    [SerializeField] private bool redZone = false;
    public bool IsRedZone
    {
        get
        {
            return redZone;
        }

        set
        {
            redZone = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if(!IsRedZone)
            {
                LevelMover.Instance.YellowZoneBool = true;
                Debug.Log("RE");
                //DEBUG 
                ground.enabled = true;

                FunctionHandler.Instance.ToggleCanvas("Ring");

                //Trigger passing into yellow zone
                parachuteTriggerEvent.Invoke(IsRedZone);
            }
            else
            {
                parachuteTriggerEvent.Invoke(IsRedZone);

            }
        }
    }


   
}
