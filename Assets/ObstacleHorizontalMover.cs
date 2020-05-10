using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHorizontalMover : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (LevelMover.instance.Moving)
        {
            transform.Translate(LevelMover.instance.offsetDir);
        }
    }

}
