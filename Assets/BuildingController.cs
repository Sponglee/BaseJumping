using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingController : Singleton<BuildingController>
{
    public class SegmentBoundaryEvent : UnityEvent<Transform> { }
    public static SegmentBoundaryEvent OnSegmentBoundary = new SegmentBoundaryEvent();

    public float flightPosition = -10f;

    public float segmentOffset;
    public Transform segmentSpawnPoint;
    

    private void Start()
    {
        FunctionHandler.OnRunningStateChange.AddListener(SwitchToFallingPosition);
        OnSegmentBoundary.AddListener(RespawnSegment);

    }

    public void SwitchToFallingPosition(bool value)
    {
        if(value == true)
            transform.position = new Vector3(transform.position.x, transform.position.y, flightPosition);
    }

    private void RespawnSegment(Transform target)
    {
        target.position = transform.GetChild(transform.childCount - 1).position - Vector3.up * segmentOffset;
        target.SetAsLastSibling();
    }
}
