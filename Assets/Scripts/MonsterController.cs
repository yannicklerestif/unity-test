using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public float speed;

    private float _currentSpeed;
    private Renderer _renderer;

    void Start()
    {
        left.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        _currentSpeed = speed;
        _renderer = GetComponent<Renderer>();

    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + _currentSpeed, transform.position.y, transform.position.z);
        if (_currentSpeed > 0) // travelling right, checking right bound to see if we must change direction
        {
            if (_renderer.bounds.max.x > right.gameObject.transform.position.x)
            {
                _currentSpeed = -_currentSpeed;
            }
        }
        else // travelling right, checking left bound
        {
            if (_renderer.bounds.min.x < left.gameObject.transform.position.x)
            {
                _currentSpeed = -_currentSpeed;
            }
        }
    }

    void Update()
    {

    }
}
