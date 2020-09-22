using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionInput : PhysicsBase
{

    void FixedUpdate()
    {
        // Rigidbody.MovePosition does the same as setting transform.position, but calculates collision along the way.
        // this adds the product of player input thrust value and time to current position 
        rb.MovePosition(transform.position + (playerInput * thrust * Time.deltaTime));
    }

}
