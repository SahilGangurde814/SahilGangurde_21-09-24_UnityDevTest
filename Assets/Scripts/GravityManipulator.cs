using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManipulator : MonoBehaviour
{
    private Rigidbody rb;
    private float Gravity = 9.81f;
    //Vector3 currentGravity;
    //Vector3 currentRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb == null)
            return;

        gravityChanger();
    }

    void gravityChanger()
    {

        // changing gravity and rotation for every condition.
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (Physics.gravity == Vector3.back && transform.eulerAngles.x == -90)
            {
                Physics.gravity = Vector3.down * Gravity;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Physics.gravity == Vector3.up && transform.eulerAngles.x == 180)
            {
                Physics.gravity = Vector3.forward * Gravity;
                transform.rotation = Quaternion.Euler(-90, 0, 360);
            }
            else
            {
                Physics.gravity = Vector3.forward * Gravity;
                transform.rotation = Quaternion.Euler(-90, 0, 0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (Physics.gravity == Vector3.forward * Gravity)
            {
                Debug.Log("Down");
                Physics.gravity = Vector3.down * Gravity;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                Debug.Log("Back");
                Physics.gravity = Vector3.back * Gravity;
                transform.rotation = Quaternion.Euler(90, 0, 0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (Physics.gravity == Vector3.right * Gravity && transform.eulerAngles.z == 90)
            {
                Physics.gravity = Vector3.up * Gravity;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                Physics.gravity = Vector3.right * Gravity;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (Physics.gravity ==Vector3.right && transform.eulerAngles.z == 90)
            {
                Physics.gravity = Vector3.down * Gravity;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                Physics.gravity = Vector3.left * Gravity;
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
        }

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    currentRotation = transform.localRotation.eulerAngles;

        //    //currentGravity = Physics.gravity.normalized;

        //    //currentRotation = transform.forward * 90;
        //    currentRotation.x -= 90;
        //    currentGravity = transform.forward * Gravity;

        //    transform.rotation = Quaternion.Euler(currentRotation);
        //    Physics.gravity = currentGravity;

        //    Debug.Log("rotation : " + currentRotation + "Gravity : " + currentGravity);
        //}
    }
}