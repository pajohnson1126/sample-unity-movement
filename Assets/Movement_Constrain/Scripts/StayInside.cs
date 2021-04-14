using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour {

	public Bounds bounds;

	private void Start ()
	{
		bounds = new Bounds (new Vector3 (0, 0, 0), new Vector3 (10, 8, 1));
	}

	void Update ()
	{
		// constrain to bounding box
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, bounds.min.x, bounds.max.x),
			Mathf.Clamp (transform.position.y, bounds.min.y, bounds.max.y),
			transform.position.z);
	}
}
