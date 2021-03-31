using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithArrowKeys : MonoBehaviour {


	public float speed = 3.0f;
	public float rotateSpeed = 2.0f;


	void Update ()
	{

		if (Input.GetKey (KeyCode.UpArrow)) {
			this.transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			this.transform.Translate (Vector3.back * speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.Rotate (Vector3.up, -rotateSpeed);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Rotate (Vector3.up, rotateSpeed);
		}

	}


}
