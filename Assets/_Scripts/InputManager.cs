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



    private LevelMover _levelMover;

    [Header("MovementControls")]
    [SerializeField] private float sideSpeed = 1f;
    [SerializeField] private float xBound = 1f;
    [SerializeField] private float zBound = 1f;
    [SerializeField] private float moveResistance = 0.2f;

    private void Start()
    {
        _levelMover = LevelMover.Instance;
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
            //if (Mathf.Abs(playerMover.localPosition.x) >= 1.3f || Mathf.Abs(playerMover.localPosition.z) >= 1f)
            //{
            //    delta = (touchPos - playerMover.position);
            //}

            charInput = new Vector3(touchPos.x - delta.x, 0f, touchPos.z - delta.z);
            playerMover.localPosition = charInput;



            playerMover.localPosition = new Vector3(Mathf.Clamp(playerMover.localPosition.x, -xBound, xBound), 
                playerMover.localPosition.y, 
                Mathf.Clamp(playerMover.localPosition.z, -zBound, zBound));


            if (Mathf.Abs(playerMover.localPosition.x) > moveResistance || Mathf.Abs(playerMover.localPosition.z) > 0.2f)
            {
                //Debug.Log("MOVE");
                _levelMover.offsetDir = -(sideSpeed  * playerMover.localPosition);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //charInput = Vector3.zero;
        }


    }

}
