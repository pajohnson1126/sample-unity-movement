using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAddForce : MonoBehaviour
{

    protected Rigidbody rb;
    public float thrust = 10f;
    public Vector3 direction;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // update is the best place to capture Input data 
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {

        // using AddForce() will increase velocity (doubling every second), while position updates every frame
        rb.AddForce(direction * thrust);
    }

}
