using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    // the target to rotate around 
    public GameObject target;
    // rotation speed
    float rotateSpeed = 200f;


    void Update()
    {

        // rotate this gameobject on it's own axis
        //transform.Rotate (transform.up * rotateSpeed * Time.deltaTime);
        // or
        //transform.RotateAround (transform.position, Vector3.up, Time.deltaTime * rotateSpeed);


        // rotate around a target transform
        // NOTE: if the other transform is the parent if this, then the parent's rotation affects child rotation!
        transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * rotateSpeed);

    }
}
