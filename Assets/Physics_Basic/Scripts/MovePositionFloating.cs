using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionFloating : PhysicsBase
{
    // reference https://www.youtube.com/watch?v=mFOi6W7lohk


    // amplitude (size) and frequency (speed) of the wave
    [SerializeField]
    private float _xAmplitude = .8f;
    [SerializeField]
    private float _xFrequency = .1f;

    [SerializeField]
    private float _zAmplitude = .12f;
    [SerializeField]
    private float _zFrequency = .6f;

    // return a new Vector3 from Sin / Cosine
    Vector3 VectorFromSine()
    {
        return new Vector3(
            Mathf.Sin(Time.time * _xFrequency) * _xAmplitude,
            0f,
            Mathf.Cos(Time.time * _zFrequency) * _zAmplitude
        );
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // get new position from wave
        Vector3 newPos = VectorFromSine();

        // add the product of newPos * thrust value * time to current position 
        rb.MovePosition(transform.position + (newPos * thrust * Time.deltaTime));
    }
}
