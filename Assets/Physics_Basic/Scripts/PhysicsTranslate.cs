using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTranslate : MonoBehaviour
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
        MoveCube(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }

    void MoveCube(Vector3 direction)
    {
        transform.Translate(direction * thrust * Time.deltaTime);
    }

}
