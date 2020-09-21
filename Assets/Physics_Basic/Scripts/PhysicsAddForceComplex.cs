using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAddForceComplex : MonoBehaviour
{

    protected Rigidbody rb;
    public float thrust = 2f;
    public float maxSpeed = 20f;
    public Vector3 facingDirection;
    public float rotation;
    public float rotationMultiplier = 1f;
    public bool applyNewDirection = false;
    public float newDirectionTime = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(NewDirectionGenerator());
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            // update is the best place to capture Input data 
            facingDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
        else if (applyNewDirection)
        {
            // change facing direction
            facingDirection = RandomDirectionFromCurrent(2.0f);
            // turn to direction 
            StartCoroutine(RotateToNewDirection(facingDirection, 0.25f));
            applyNewDirection = false;
        }


        transform.Rotate(facingDirection.x * rotationMultiplier * Vector3.up, Space.World);

    }


    Vector3 RandomDirectionFromCurrent(float distance)
    {
        return new Vector3(
                Random.Range(-distance, distance),
                Random.Range(0, 0),
                Random.Range(-distance, distance)
            );
    }
    IEnumerator RotateToNewDirection(Vector3 facingDirection, float timeToRotate)
    {
        Quaternion targetRotation = Quaternion.LookRotation(facingDirection);
        Quaternion currentRotation = transform.rotation;
        for (float i = 0; i < 1.0f; i += Time.deltaTime / timeToRotate)
        {
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, i);
            yield return null;
        }
    }
    // generate a new random direction at random times
    IEnumerator NewDirectionGenerator()
    {
        // run forever
        while (true)
        {
            // pick new time to wait before generating new force vector 
            newDirectionTime = Random.Range(3.0f, 8.0f);

            applyNewDirection = true;

            // wait for before next loop
            yield return new WaitForSeconds(newDirectionTime);
        }
    }

    void FixedUpdate()
    {


        // using AddForce() will increase velocity (doubling every second), while position updates every frame
        rb.AddForce(transform.forward * thrust);
    }





}
