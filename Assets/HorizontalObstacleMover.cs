using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleMover : MonoBehaviour
{



    [SerializeField] private float _moveSpeed = 2f;
    [Header ("Random move speed control")]
    [SerializeField] private bool _generateMoveSpeed = false;
    [SerializeField] private float _lowerSpeedLimit = 0f;
    [SerializeField] private float _upperSpeedLimit = 1f;
    private void Start()
    {
        if (_generateMoveSpeed)
            _moveSpeed = Random.Range(_lowerSpeedLimit, _upperSpeedLimit);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * _moveSpeed);
    }



}
