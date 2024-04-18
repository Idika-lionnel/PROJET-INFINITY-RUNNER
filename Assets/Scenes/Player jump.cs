using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerjump : MonoBehaviour
{


	    public float jumpForce = 30f;
	    public Rigidbody rb;

	    // Start is called before the first frame update
	    void Start()
	    {
	        rb = GetComponent<Rigidbody>();
	    }

	    // Update is called once per frame
	    void Update()
	    {
		Debug.Log(rb.velocity.y);
	        // Saut
	        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
	        {
	            rb.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);
	        }

	    }
	}
