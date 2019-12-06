using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    //[SerializeField] private protected Joystick joystick;

    public Transform playerMover;


    public float deltaX;
    public float deltaZ;

    public Vector3 charInput;
    public Vector3 touchPos;
    public Rigidbody rb;


    private void Start()
    {
        rb = playerMover.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        touchPos = Camera.main.ScreenToWorldPoint(mousePos);
        if (Input.GetMouseButtonDown(0))
        {
            deltaX = touchPos.x - playerMover.position.x;
            deltaZ = touchPos.z - playerMover.position.z;
        }
        else if (Input.GetMouseButton(0))
        {
            charInput = new Vector3(touchPos.x - deltaX, 0f, touchPos.z - deltaZ);
            playerMover.position = charInput;
            playerMover.position = new Vector3(Mathf.Clamp(playerMover.position.x, -0.7f, 0.7f), playerMover.position.y, Mathf.Clamp(playerMover.position.z, -1.3f, 0.3f));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //charInput = Vector3.zero;
        }


    }

}
