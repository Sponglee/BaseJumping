using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteInputManager : InputManager
{

    public Joystick joystick;
    


    private void Update()
    {
        charInput = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
    }

}