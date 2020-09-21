using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBase : MonoBehaviour
{

    protected Rigidbody rb;
    public float thrust = 10f;
    public Vector3 playerInput;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        // update is the best place to capture Input data 
        playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

}
