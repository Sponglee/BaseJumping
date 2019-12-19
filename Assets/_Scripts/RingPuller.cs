using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPuller : MonoBehaviour
{
    [SerializeField] private Joystick ring;


    private void Update()
    {
        //Debug.Log(ring.Vertical);
        if(ring.Vertical <=-1)
        {
            FunctionHandler.Instance.PullRing();
        }
    }
}
