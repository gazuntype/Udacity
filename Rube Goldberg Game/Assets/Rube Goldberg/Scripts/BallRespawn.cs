using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour {

	Vector3 initialPosition;
	Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log(other.gameObject.name);
		if (other.gameObject.name == "FloorPlane")
		{
			transform.position = initialPosition;
			rigidbody.velocity = Vector3.zero;
		}
	}
}
