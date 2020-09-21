using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsInfo : MonoBehaviour
{

    public float speed;
    public float angularSpeed;
    protected Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        // Any force on an object will increase velocity by that value each second
        // - e.g. Gravity will increase 9.81 until the object reaches terminal velocity
        // - affected by drag value (a.k.a. "air resistance")
        // - more drag means more resistance (feather = 20, stone = 1)
        speed = rb.velocity.magnitude;
        angularSpeed = rb.angularVelocity.magnitude;

    }

}
