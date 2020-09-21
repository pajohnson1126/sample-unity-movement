using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAddForce : PhysicsBase
{


    void FixedUpdate()
    {
        // using AddForce() will increase velocity (doubling every second), while position updates every frame
        rb.AddForce(playerInput * thrust);
    }

}
