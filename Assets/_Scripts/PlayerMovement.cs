using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform mover;

    public float movingSpeed = 10f;

    private void Update()
    {
        if (Mathf.Abs(mover.localPosition.x)>0.1f || Mathf.Abs(mover.localPosition.z)>0.1f)
        {
            Debug.Log("MOVE");
            transform.Translate(movingSpeed * mover.localPosition.normalized);
        }
    }


}
