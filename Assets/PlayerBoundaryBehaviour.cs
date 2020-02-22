using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaryBehaviour : MonoBehaviour
{
    

    public PlayerMover.BoundarySide dropDown = PlayerMover.BoundarySide.BoundaryX;  // this public var should appear as a drop down


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMover.Instance.boundaryReached = dropDown;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMover.Instance.boundaryReached = PlayerMover.BoundarySide.None;
        }
    }
}
