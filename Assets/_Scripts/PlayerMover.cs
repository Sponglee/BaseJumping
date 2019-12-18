using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public Transform model;
    public Transform charachterTransform;
    public InputManager _inputManager;
    private LevelMover _levelMover;

    [Header("MovementControls")]
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float sideSpeed = 1f;
    [SerializeField] private float xBound = 1f;
    [SerializeField] private float zBound = 1f;
    [SerializeField] private float moveResistance = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        //_inputManager = GetComponent<InputManager>();
        _levelMover = LevelMover.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(_levelMover.ParachuteBool && _levelMover.Moving)
        {
            //charachterTransform.localPosition = _inputManager.charInput;
            //charachterTransform.localPosition = new Vector3(Mathf.Clamp(charachterTransform.localPosition.x, -xBound, xBound),
            //    charachterTransform.localPosition.y,
            //    Mathf.Clamp(charachterTransform.localPosition.z, -zBound, zBound));



            if (Mathf.Abs(charachterTransform.localPosition.x) > moveResistance || Mathf.Abs(charachterTransform.localPosition.z) > 0.2f)
            {
                //Debug.Log("MOVE");
                _levelMover.offsetDir = new Vector3 ((charachterTransform.position-_levelMover.groundTarget.position).normalized.x ,
                                                    0, (charachterTransform.position - _levelMover.groundTarget.position).normalized.z );
            }
        }
        else if (_levelMover.Moving)
        {
            charachterTransform.localPosition = _inputManager.charInput;
            charachterTransform.localPosition = new Vector3(Mathf.Clamp(charachterTransform.localPosition.x, -xBound, xBound),
                charachterTransform.localPosition.y,
                Mathf.Clamp(charachterTransform.localPosition.z, -zBound, zBound));

            if (Mathf.Abs(charachterTransform.localPosition.x) > moveResistance || Mathf.Abs(charachterTransform.localPosition.z) > 0.2f)
            {
                //Debug.Log("MOVE");
                _levelMover.offsetDir = -(sideSpeed * charachterTransform.localPosition);
            }


            //Orientate model
            Vector3 diff = -((Camera.main.transform.position + _levelMover.offsetDir * 10f) /*+ _levelMover.offsetDir.normalized*/);
            Debug.DrawLine(transform.position, transform.position + diff, Color.red);


            Quaternion currentRotation = Quaternion.LookRotation(model.transform.position + new Vector3(diff.x, diff.y, diff.z), Vector3.forward - new Vector3(_levelMover.offsetDir.x, _levelMover.offsetDir.y, -Mathf.Abs(_levelMover.offsetDir.z)).normalized);
            model.rotation = Quaternion.Lerp(model.rotation, currentRotation, rotationSpeed * Time.deltaTime);

        }
    }
}
