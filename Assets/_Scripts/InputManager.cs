using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    [SerializeField] private protected Joystick joystick;


    public Vector3 charInput;

   


    private void Update()
    {
         charInput = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);

        //playerPivot.position = transform.position + Quaternion.AngleAxis(-20f, Vector3.up) * charInput * 20f;
    }
  
}
