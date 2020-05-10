using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlockVerticalMover : ObstacleVerticalMover
{
    protected override void BoundaryAction()
    {
        BuildingController.OnSegmentBoundary.Invoke(transform);
    }
}
