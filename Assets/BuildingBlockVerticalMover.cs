using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlockVerticalMover : ObstacleVerticalMover
{
    protected override void BoundaryTriggerAction()
    {
        BuildingController.OnSegmentBoundary.Invoke(transform);
    }
}
