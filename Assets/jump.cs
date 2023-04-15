using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody rb;
    private bool isGrounded = true;
	private float distToGround;
	public Collider collidere;
	void Start() {
		distToGround = collidere.bounds.extents.y;
	}

    void Update() {
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

