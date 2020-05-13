using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHorizontalMover : ObstacleMoverBase
{
    protected override void MovingBehaviour()
    {
        transform.Translate(LevelMover.instance.offsetDir);
    }
}
