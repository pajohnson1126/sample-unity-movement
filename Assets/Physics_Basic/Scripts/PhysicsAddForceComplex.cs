using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAddForceComplex : PhysicsBase
{

    // move around, using AddForce() don't run into walls



    public Vector3 direction;


    public double maxVelocity = 10f;




    //public float maxSpeed = 20f;
    //public float rotation;
    //public float rotationMultiplier = 1f;
    //public bool applyNewDirection = false;
    //public float newDirectionTime = 0;


    void Start()
    {
        //StartCoroutine(NewDirectionGenerator());
    }

    protected override void Update()
    {
        // call in base 
        base.Update();
        // normalize input (make sure vector's total length never exceeds 1)
        playerInput = Vector2.ClampMagnitude(direction, 1f);



        //else if (applyNewDirection)
        //{
        //    // change direction
        //    direction = RandomDirectionFromCurrent(2.0f);
        //    // turn to direction 
        //    StartCoroutine(RotateToNewDirection(direction, 0.25f));
        //    direction = false;
        //}


        //transform.Rotate(direction.x * rotationMultiplier * Vector3.up, Space.World);

    }


    //Vector3 RandomDirectionFromCurrent(float distance)
    //{
    //    return new Vector3(
    //            Random.Range(-distance, distance),
    //            Random.Range(0, 0),
    //            Random.Range(-distance, distance)
    //        );
    //}
    //IEnumerator RotateToNewDirection(Vector3 direction, float timeToRotate)
    //{
    //    Quaternion targetRotation = Quaternion.LookRotation(direction);
    //    Quaternion currentRotation = transform.rotation;
    //    for (float i = 0; i < 1.0f; i += Time.deltaTime / timeToRotate)
    //    {
    //        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, i);
    //        yield return null;
    //    }
    //}
    //// generate a new random direction at random times
    //IEnumerator NewDirectionGenerator()
    //{
    //    // run forever
    //    while (true)
    //    {
    //        // pick new time to wait before generating new force vector 
    //        newDirectionTime = Random.Range(3.0f, 8.0f);

    //        applyNewDirection = true;

    //        // wait for before next loop
    //        yield return new WaitForSeconds(newDirectionTime);
    //    }
    //}

    void FixedUpdate()
    {
        // if velocity is too great do not add force
        if (rb.velocity.magnitude >= maxVelocity) return;

        // using AddForce() will increase velocity (doubling every second), while position updates every frame
        rb.AddForce(transform.forward * thrust);
    }







    //IEnumerator PositionGenerator()
    //{
    //    while (true)
    //    {
    //        float noise = Mathf.PerlinNoise(Time.deltaTime, y);

    //        //pick new time to wait before generating new force vector
    //        float wait = Random.Range(3.0f, 8.0f);

    //        applyNewDirection = true;

    //        // wait for before next loop
    //        yield return new WaitForSeconds(wait);
    //    }
    //}

}
