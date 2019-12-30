using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Singleton<PlayerMover>
{
    public Transform model;
    public Transform charachterTransform;
    public InputManager _inputManager;

    public Transform parachuteHolder;
    public Transform preParachuteHolder;
    public Transform trailHolder;

    //[SerializeField] private Joystick joystick;

    [Header("MovementControls")]
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float sideSpeed = 1f;
    [SerializeField] private float xBound = 1f;
    [SerializeField] private float zBound = 1f;
    [SerializeField] private float moveResistance = 0.2f;


    private void Start()
    {
        LevelMover.trailEvent.AddListener(EnableTrail);
    }

    // Update is called once per frame
    void Update()
    {
        if((LevelMover.instance.PreParachuteBool || LevelMover.instance.ParachuteBool) && LevelMover.instance.Moving)
        {

            //Offset valute to head to the target
            LevelMover.instance.offsetDir = new Vector3((charachterTransform.position - LevelMover.instance.groundTarget.position).normalized.x,
                                                0, (charachterTransform.position - LevelMover.instance.groundTarget.position).normalized.z);
           
            //Click to Speed up clicks
            if(Input.GetMouseButtonDown(0))
            {
                RingPuller.ringPullSpeedUp.Invoke();    
            }

        }
        else if (LevelMover.instance.Moving)
        {
            charachterTransform.localPosition = _inputManager.charInput;
            charachterTransform.localPosition = new Vector3(Mathf.Clamp(charachterTransform.localPosition.x, -xBound, xBound),
                charachterTransform.localPosition.y,
                Mathf.Clamp(charachterTransform.localPosition.z, -zBound, zBound));

            if (Mathf.Abs(charachterTransform.localPosition.x) > moveResistance || Mathf.Abs(charachterTransform.localPosition.z) > 0.2f)
            {
                //Debug.Log("MOVE");
                LevelMover.instance.offsetDir = -(sideSpeed * charachterTransform.localPosition);
            }


            //Orientate model
            Vector3 diff = -((Camera.main.transform.position + LevelMover.instance.offsetDir * 10f) /*+ LevelMover._levelMover.offsetDir.normalized*/);
            Debug.DrawLine(transform.position, transform.position + diff, Color.red);


            Quaternion currentRotation = Quaternion.LookRotation(model.transform.position + new Vector3(diff.x, diff.y, diff.z), Vector3.forward - new Vector3(LevelMover.instance.offsetDir.x, LevelMover.instance.offsetDir.y, -Mathf.Abs(LevelMover.instance.offsetDir.z)).normalized);
            model.rotation = Quaternion.Lerp(model.rotation, currentRotation, rotationSpeed * Time.deltaTime);

        }
    }

    public void SwitchMovement()
    {
        GetComponent<GlidingInputManager>().enabled = false;
        ParachuteInputManager parachute = GetComponent<ParachuteInputManager>();


        parachute.enabled = true;
        parachute.joystick.gameObject.SetActive(true);
        _inputManager = parachute;
    }

    public void EnableTrail()
    {
        trailHolder.gameObject.SetActive(true);
        LevelMover.trailEvent.AddListener(DisableTrail);
    }

    public void DisableTrail()
    {
        trailHolder.gameObject.SetActive(false);
        LevelMover.trailEvent.AddListener(EnableTrail);
    }
}
