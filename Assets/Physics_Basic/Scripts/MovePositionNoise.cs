using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionNoise : PhysicsBase
{
    public Vector3 newPos;


    // random position from Perlin noise
    Vector3 VectorFromNoise()
    {
        // create noise for position 
        float noise = Mathf.PerlinNoise(Time.time, Time.time);

        return new Vector3(
                Random.Range(-noise, noise),
                0,
                Random.Range(-noise, noise)
            );
    }

    void FixedUpdate()
    {
        // get new position from noise
        newPos = VectorFromNoise();

        // add the product of newPos * thrust value * time to current position 
        rb.MovePosition(transform.position + (newPos * thrust * Time.deltaTime));
    }



}
