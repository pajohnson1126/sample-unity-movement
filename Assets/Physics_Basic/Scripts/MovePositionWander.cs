using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionWander : PhysicsBase
{
    public Vector3 newPos;
    Collider worldContainerCollider;    // collider to test new positions
    public Vector3 wayPoint;            // new position to head towards
    public float distanceToTarget = 3f;  // test distance to target
    public float pointSelectRange = 6f; // range from which to select new wayPoint



    private void Start()
    {
        // get container collider
        worldContainerCollider = GameObject.Find("WorldContainer").GetComponent<Collider>();

        // first wander point
        wayPoint = ReturnNewWanderPoint();
    }

    void FixedUpdate()
    {

        // when the distance between gameObject and target is close enough
        if ((transform.position - wayPoint).magnitude < distanceToTarget)
        {
            // create a new target wayPoint 
            wayPoint = ReturnNewWanderPoint();
        }

        Debug.Log(wayPoint + " and " + (transform.position - wayPoint).magnitude);


        // look at wayPoint
        transform.LookAt(wayPoint);
        // uses transform to teleport
        transform.position += transform.TransformDirection(Vector3.forward) * thrust * Time.deltaTime;

        // add the product of newPos * thrust value * time to current position 
        //rb.MovePosition(transform.position + (newPos * thrust * Time.deltaTime));
    }





    /**
      *  Return a new nearby point to head toward
      */

    Vector3 ReturnNewWanderPoint()
    {
        bool safe = false;
        Vector3 newPoint = Vector3.zero;
        // loop until new point is within safe area
        while (!safe)
        {
            newPoint = new Vector3(
                Random.Range(transform.position.x - pointSelectRange, transform.position.x + pointSelectRange),
                1,
                Random.Range(transform.position.z - pointSelectRange, transform.position.z + pointSelectRange)
            );
            Debug.Log("Point in collider = " + IsPointWithinCollider(worldContainerCollider, newPoint));
            // if found to be within safe area then return
            safe = IsPointWithinCollider(worldContainerCollider, newPoint);
        }
        return newPoint;
    }


    /**
     *  Return true if point is inside collider
     */
    public static bool IsPointWithinCollider(Collider collider, Vector3 point)
    {
        return (collider.ClosestPoint(point) - point).sqrMagnitude < Mathf.Epsilon * Mathf.Epsilon;
    }



    /**
     *  Return random Vector3 position inside bounds
     */
    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }


}
