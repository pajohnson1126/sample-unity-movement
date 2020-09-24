using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GOAL: move around, using AddForce() don't run into walls

public class AddForceWander : PhysicsBase
{
    public bool applyNewDirection;
    public Vector3 newDirection;

    [SerializeField]
    private float _xRange = .1f;
    [SerializeField]
    private float _zRange = .1f;



    private void Start()
    {
        StartCoroutine(DirectionGenerator());
    }


    protected override void Update()
    {


        // then do it automatically
        if (applyNewDirection)
        {
            newDirection = transform.position + NewDirection();
            applyNewDirection = false;
        }



    }




    void FixedUpdate()
    {
        //playerInput += newDirection;

        // if velocity is too great do not add force
        if (rb.velocity.magnitude >= maxVelocity) return;

        // using AddForce() will increase velocity (doubling every second), while position updates every frame
        rb.AddForce(newDirection * thrust);
    }




    Vector3 NewDirection()
    {
        Vector3 direction = new Vector3(
                Random.Range(-_xRange, _xRange),
                0,
                Random.Range(-_zRange, _zRange)
            );
        return direction;
    }
    IEnumerator DirectionGenerator()
    {
        while (true)
        {
            applyNewDirection = true;

            // wait for before next loop
            yield return new WaitForSeconds(1f);
        }
    }




}
