using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody rb;
    bool grounded;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.position -= transform.right * Time.deltaTime * 2f;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.position += transform.right * Time.deltaTime * 2f;
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.position += transform.forward * Time.deltaTime * 2f;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.position -= transform.forward * Time.deltaTime * 2f;
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        //look around on Y-axis with mouse
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);
        Cursor.lockState = CursorLockMode.Locked; //locking mouse cursor to screen area
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * 150f);
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Plane")
        {
            grounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            grounded = true;
        }
    }
}
