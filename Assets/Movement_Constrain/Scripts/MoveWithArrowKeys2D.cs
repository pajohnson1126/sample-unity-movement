using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithArrowKeys2D : MonoBehaviour {


	public float speed = 30.0f;


	void Update ()
	{

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			this.transform.Translate (Vector3.down * speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.Translate (Vector3.left * speed * Time.deltaTime);
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Translate (Vector3.right * speed * Time.deltaTime);
			transform.localScale = new Vector3 (-1, 1, 1);
		}

	}


}
