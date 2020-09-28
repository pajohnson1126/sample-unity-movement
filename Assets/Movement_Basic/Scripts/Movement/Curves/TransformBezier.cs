using UnityEngine;


public class TransformBezier : MonoBehaviour {

	public Vector3 direction;
	public float speed = .1f;

	public Vector3 vertex;
	public Vector3 target;
	public Vector3 lastPosition;

	public float distanceFromTarget;
	public float curveScalar = 5.0f;
	float distanceTraveled = 0.0f;

	void Awake ()
	{
		Reset ();
	}

	void Update ()
	{
		// update distance
		distanceFromTarget = (transform.position - target).magnitude;

		// if reset 
		if (distanceTraveled < 1.0f) {
			// add speed * time
			distanceTraveled += speed * Time.deltaTime;
			// get direction from angles
			Vector3 m1 = Vector3.Lerp (lastPosition, vertex, distanceTraveled);
			Vector3 m2 = Vector3.Lerp (vertex, target, distanceTraveled);
			direction = Vector3.Lerp (m1, m2, distanceTraveled);
			transform.position = direction;
		}

		if (distanceFromTarget < 1) {
			Reset ();
		}

		// updated position and angle rays
		ShowRayBetweenPoints (transform.position, target, Color.green);
		ShowRayBetweenPoints (lastPosition, target, Color.yellow);
		ShowRayBetweenPoints (lastPosition, vertex, Color.blue);
		ShowRayBetweenPoints (target, vertex, Color.red);
	}


	void Reset ()
	{
		Debug.Log ("Reset()");
		lastPosition = transform.position;
		distanceTraveled = 0.0f;
		target = ReturnRandomPoint (0, 30);
		vertex = ReturnVertex (transform.position, target);
	}


	Vector3 ReturnRandomPoint (float min, float max)
	{
		return new Vector3 (
			Random.Range (min, max),
			1,
			Random.Range (min, max)
		);
	}


	Vector3 ReturnVertex (Vector3 point0, Vector3 point2)
	{
		// Assuming point[0] and point[2] are your starting point and destination
		// and all points are Vector3
		return point0 + (point2 - point0) / 2 + Vector3.forward * curveScalar; // Play with 5.0 to change the curve

	}


	/**
	 *	Show ray between two points 
	 */
	void ShowRayBetweenPoints (Vector3 p1, Vector3 p2, Color c)
	{
		Debug.DrawRay (p1, (p2 - p1), c);
	}

}