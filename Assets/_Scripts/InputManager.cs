using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    //[SerializeField] private protected Joystick joystick;

    public Transform playerMover;


    public Vector3 delta;


    public Vector3 charInput;
    public Vector3 touchPos;
    public Rigidbody rb;

    public Transform holder;

    private void Start()
    {
        rb = playerMover.GetComponent<Rigidbody>();
    }

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
            playerMover.position = charInput;
            playerMover.localPosition = new Vector3(Mathf.Clamp(playerMover.localPosition.x, -1f, 1f), 
                playerMover.localPosition.y, 
                Mathf.Clamp(playerMover.localPosition.z, -1.3f, 1.3f));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //charInput = Vector3.zero;
        }


    }

}
