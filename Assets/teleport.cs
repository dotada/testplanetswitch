using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

	public Transform transformer;
	public Rigidbody rb;
	public GameObject planetnewtp;
	public GameObject cubetp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1)){
			rb.velocity = new Vector3(0f, 0f, 0f);
			transformer.position = planetnewtp.transform.position;
		}
		if (Input.GetKeyDown(KeyCode.F2)){
			rb.velocity = new Vector3(0f, 0f, 0f);
			transformer.position = cubetp.transform.position;
		}
    }
}
