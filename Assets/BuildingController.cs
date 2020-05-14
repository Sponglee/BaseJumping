using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingController : Singleton<BuildingController>
{
    public class SegmentBoundaryEvent : UnityEvent<Transform> { }
    public static SegmentBoundaryEvent OnSegmentBoundary = new SegmentBoundaryEvent();

    public float flightPosition = -10f;
    public float goalOffset = 20f;
    public int numberOfSegments = 5;

    public float segmentOffset;
    public Transform goalsHolder;   

    public AnimationCurve curve;
    public GameObject goalPrefab;

    public GameObject segmentPref;
    public GameObject goalPref;
    public GameObject balconyPref;

    private void Start()
    {
        FunctionHandler.OnRunningStateChange.AddListener(SwitchToFallingPosition);
        OnSegmentBoundary.AddListener(RespawnSegment);

    }

    public void SwitchToFallingPosition(bool value)
    {
        if (value == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, flightPosition);
            SpawnSegments();    
        }

    }

    private void SpawnSegments()
    {
        for (int i = 0; i < numberOfSegments; i++)
        {
            GameObject tmpSegment = Instantiate(segmentPref, transform.position - Vector3.up*segmentOffset*(i+2),Quaternion.identity, transform);
            tmpSegment.transform.SetAsLastSibling();
            tmpSegment.GetComponent<SegmentBehaviour>().SpawnContent(goalPref,balconyPref);
        }
    }

    private void RespawnSegment(Transform targetSegment)
    {
        targetSegment.position = transform.GetChild(transform.childCount - 1).position - Vector3.up * segmentOffset;
        targetSegment.SetAsLastSibling();
        targetSegment.GetComponent<SegmentBehaviour>().DespawnContent();
        if(!LevelMover.instance.YellowZoneBool && !LevelMover.instance.RedZoneBool)
        {
            targetSegment.GetComponent<SegmentBehaviour>().SpawnContent(goalPref, balconyPref);
        }
       
    }

    //public void SpawnGoalLayer(Transform target, float offsetValue)
    //{
      
    //    GameObject tmpGoal = Instantiate(goalPrefab, target.position + Vector3.up * target.GetSiblingIndex() * offsetValue, Quaternion.identity, target);

    //    tmpGoal.transform.position = new Vector3(curve.Evaluate(tmpGoal.transform.position.y / target.position.y) * 100f, tmpGoal.transform.position.y, 0f);

    //}
}
