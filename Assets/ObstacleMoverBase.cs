using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoverBase : MonoBehaviour
{
    [SerializeField] private bool gameRunning = false;
    public bool GameRunning
    {
        get
        {
            return gameRunning;
        }

        set
        {
            gameRunning = value;
        }
    }

    private void Start()
    {
        FunctionHandler.OnRunningStateChange.AddListener(SetMoverRunning);
    }

    private void SetMoverRunning(bool value)
    {
        GameRunning = value;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameRunning)
        {
            MovingBehaviour();
        }
    }

    protected virtual void MovingBehaviour()
    {

    }

}
