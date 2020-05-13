using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Singleton<PlayerMover>
{
    public Transform model;
    public Transform charachterTransform;
    public InputManager inputManager;

    public InputManager[] inputManagers;

    public Transform parachuteHolder;
    public Transform preParachuteHolder;
    public Transform trailHolder;

    //Parachute control constraints
    public Vector2 parachuteAngleConstraintsX;
    public Vector2 parachuteAngleConstraintsZ;
    public float controlMultiplier = 5f;

    //[SerializeField] private Joystick joystick;

    [Header("MovementControls")]
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float sideSpeed = 1f;
    [SerializeField] private float xBound = 1f;
    [SerializeField] private float zBound = 1f;
    [SerializeField] private float moveResistance = 0.2f;
    public float speedModifier = 1;

    public Vector3 playerOffset;

    public BoundarySide boundaryReached=BoundarySide.None;

    public enum BoundarySide // your custom enumeration
    {
        None,
        BoundaryX,
        BoundaryZ
    };


    private void Start()
    {
        LevelMover.trailEvent.AddListener(EnableTrail);

        RingPuller.parachuteDeployed.AddListener(SwitchMovement);
       
    }

    // Update is called once per frame
    void Update()
    {
        if((LevelMover.instance.PreParachuteBool || LevelMover.instance.ParachuteBool) && LevelMover.instance.Moving)
        {

            //charachterTransform.localPosition = Vector3.zero;
            //Offset valute to head to the target
            Vector3 targetDirection = new Vector3((transform.position - LevelMover.instance.groundTarget.position).normalized.x,
                                                0, (transform.position - LevelMover.instance.groundTarget.position).normalized.z);

            //Vector3 targetDirection = Vector3.up;

            Vector3 controlDirection = new Vector3(-inputManager.charInput.x,
                                                   inputManager.charInput.z / 2,
                                                   inputManager.charInput.z);


            playerOffset = targetDirection /*+ controlDirection*/;



            //Orientate model

            parachuteHolder.eulerAngles = new Vector3(Mathf.Clamp(controlDirection.z*controlMultiplier, parachuteAngleConstraintsX.x, parachuteAngleConstraintsX.y),
                                                        0,
                                                        Mathf.Clamp(controlDirection.x * controlMultiplier, parachuteAngleConstraintsZ.x, parachuteAngleConstraintsZ.y));



            //Quaternion currentRotation = Quaternion.LookRotation(parachuteHolder.forward + new Vector3(controlDirection.x, controlDirection.z, 0).normalized, Vector3.up);
            //parachuteHolder.rotation = Quaternion.Lerp(parachuteHolder.rotation, currentRotation, rotationSpeed * Time.deltaTime);

        }
        else if (LevelMover.instance.Moving)
        {
            charachterTransform.localPosition = inputManager.charInput;
            charachterTransform.localPosition = new Vector3(Mathf.Clamp(charachterTransform.localPosition.x, -xBound, xBound),
                charachterTransform.localPosition.y,
                Mathf.Clamp(charachterTransform.localPosition.z, -zBound, zBound));

            if (boundaryReached == BoundarySide.BoundaryX)
            {
                LevelMover.instance.offsetDir = new Vector3(0, 0, -sideSpeed * charachterTransform.localPosition.z);
            }
            else if (boundaryReached == BoundarySide.BoundaryZ)
            {
                LevelMover.instance.offsetDir = new Vector3(-sideSpeed * charachterTransform.localPosition.x, 0, 0) * speedModifier;
            }
            else if ((Mathf.Abs(charachterTransform.localPosition.x) > moveResistance || Mathf.Abs(charachterTransform.localPosition.z) > 0.2f) && boundaryReached == BoundarySide.None)
            {
                
                //Debug.Log("MOVE");
                LevelMover.instance.offsetDir = -(sideSpeed * charachterTransform.localPosition);
            }
            else
            {
                LevelMover.instance.offsetDir = Vector3.zero ;
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

        //Set model to parachute's pivot for movement rotation
        model.SetParent(parachuteHolder.GetChild(0));
        model.localPosition = Vector3.zero;


        //model = parachuteHolder;
        parachute.enabled = true;
        parachute.joystick.gameObject.SetActive(true);
        inputManager = parachute;
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
