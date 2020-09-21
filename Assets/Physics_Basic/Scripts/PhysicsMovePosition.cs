using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovePosition : PhysicsBase
{


    void FixedUpdate()
    {

        // Rigidbody.MovePosition does the same as setting transform.position, but calculates collision along the way.
        rb.MovePosition(transform.position + (playerInput * thrust * Time.deltaTime));
    }

}
