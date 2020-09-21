using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovePosition : MonoBehaviour
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

        // Rigidbody.MovePosition does the same as setting transform.position, but calculates collision along the way.
        rb.MovePosition(transform.position + (direction * thrust * Time.deltaTime));
    }

}
