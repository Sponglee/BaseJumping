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
                GameManager.Instance.GameWin(other.transform);
            }
            else
            {
                GameManager.Instance.GameOver();

            }
        }
    }

}

            
