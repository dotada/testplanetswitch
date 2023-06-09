using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveandlookaround : MonoBehaviour
{
	private Rigidbody rb;
	public float sensitivity = 5.0f;
	public float minYangle = -90.0f;
	public float maxYangle = 90.0f;
	private float rotationX = 0.0f;
	private float rotationY = 0.0f;
	private Camera playerCam;
	public float speed = 5.0f;
	public float jumpForce;
    private bool isGrounded = true;
	private float distToGround;
	public Collider collidere;
	
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		playerCam = transform.Find("Playercam").GetComponent<Camera>();
		Cursor.lockState = CursorLockMode.Locked;
		distToGround = collidere.bounds.extents.y;
    }

    void Update()
    {
		rotationX += Input.GetAxis("Mouse X") * sensitivity;
		rotationY += Input.GetAxis("Mouse Y") * sensitivity;
		rotationY = Mathf.Clamp(rotationY, minYangle, maxYangle);
		transform.rotation = Quaternion.Euler(0, rotationX, 0);
		playerCam.transform.localRotation = Quaternion.Euler(-rotationY, 0, 0);

		Vector3 movement = Vector3.zero;

    	if (Input.GetKey(KeyCode.W)) {
        	movement += transform.forward;
    	}
    	if (Input.GetKey(KeyCode.S)) {
        	movement -= transform.forward;
    	}
    	if (Input.GetKey(KeyCode.A)) {
        	movement -= transform.right;
    	}
    	if (Input.GetKey(KeyCode.D)) {
        	movement += transform.right;
    	}
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

    	// Move the player based on the input values
    	transform.position += movement.normalized * speed * Time.deltaTime;

		isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
		Debug.Log("isGrounded: " + isGrounded);
        // Jump if grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
			isGrounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
