using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReaction : MonoBehaviour {
	Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log(other.gameObject.name);
		switch (other.gameObject.name)
		{
			case "Teleporter Pad A(Clone)":
				Debug.Log("I know it's a telport pad");
				TeleportBall();
				break;
		}
	}

	void TeleportBall()
	{
		GameObject teleportTarget;
		teleportTarget = GameObject.Find("Teleport_Target(Clone)");
		if (teleportTarget != null)
		{
			teleportTarget.GetComponent<Collider>().enabled = false;
			transform.position = teleportTarget.transform.position;
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}
