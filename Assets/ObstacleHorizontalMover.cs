using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHorizontalMover : ObstacleMoverBase
{
    protected override void MovingBehaviour()
    {
        transform.position = new Vector3(transform.position.x + LevelMover.instance.offsetDir.x, transform.position.y, transform.position.z);
    }
}
