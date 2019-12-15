using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Transform playerMover;

    public Vector3 delta;
    public Vector3 charInput;
    public Vector3 touchPos;

    private void Update()
    {
       
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;

            touchPos = Camera.main.ScreenToWorldPoint(mousePos) /*- holder.position*/;
            if (Input.GetMouseButtonDown(0))
            {
                delta = (touchPos - playerMover.position);
            }
            else if (Input.GetMouseButton(0))
            {
                charInput = new Vector3(touchPos.x - delta.x, 0f, touchPos.z - delta.z);
            }
    }

}
