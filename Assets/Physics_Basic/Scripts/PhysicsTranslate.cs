using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTranslate : PhysicsBase
{


    protected override void Update()
    {
        // call in base 
        base.Update();
        MoveCube();
    }

    void MoveCube()
    {
        transform.Translate(playerInput * thrust * Time.deltaTime);
    }

}
