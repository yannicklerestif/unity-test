using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject patrolPath;
    public float speed;

    private float _currentSpeed;
    private Renderer _renderer;
    private PatrolPathController _patrolPathController;

    void Start()
    {
        _currentSpeed = speed;
        _renderer = GetComponent<Renderer>();
        _patrolPathController = patrolPath.GetComponent<PatrolPathController>();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + _currentSpeed * Time.deltaTime, transform.position.y,
            transform.position.z);
        if (_currentSpeed > 0) // travelling right, checking right bound to see if we must change direction
        {
            if (_renderer.bounds.max.x > _patrolPathController.right.gameObject.transform.position.x)
            {
                _currentSpeed = -_currentSpeed;
            }
        }
        else // travelling right, checking left bound
        {
            if (_renderer.bounds.min.x < _patrolPathController.left.gameObject.transform.position.x)
            {
                _currentSpeed = -_currentSpeed;
            }
        }
    }
}