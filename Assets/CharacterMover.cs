using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{

    public Transform playerMover;
    public InputManager _inputManager;
    private LevelMover _levelMover;

    [Header("MovementControls")]
    [SerializeField] private float sideSpeed = 1f;
    [SerializeField] private float xBound = 1f;
    [SerializeField] private float zBound = 1f;
    [SerializeField] private float moveResistance = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _levelMover = LevelMover.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (_levelMover.Moving)
        {
            playerMover.localPosition = _inputManager.charInput;
            playerMover.localPosition = new Vector3(Mathf.Clamp(playerMover.localPosition.x, -xBound, xBound),
                playerMover.localPosition.y,
                Mathf.Clamp(playerMover.localPosition.z, -zBound, zBound));

            if (Mathf.Abs(playerMover.localPosition.x) > moveResistance || Mathf.Abs(playerMover.localPosition.z) > 0.2f)
            {
                //Debug.Log("MOVE");
                _levelMover.offsetDir = -(sideSpeed * playerMover.localPosition);
            }
        }
    }
}
