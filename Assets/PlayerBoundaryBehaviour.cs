using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaryBehaviour : MonoBehaviour
{
    private LevelMover levelMover;

    public PlayerMover.BoundarySide dropDown = PlayerMover.BoundarySide.BoundaryX;  // this public var should appear as a drop down

    public Material gridMaterial;

    private void Start()
    {

        levelMover = LevelMover.Instance; 
    }

    private void FixedUpdate()
    {
        gridMaterial.mainTextureOffset += new Vector2(0,0.1f);
    }

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
