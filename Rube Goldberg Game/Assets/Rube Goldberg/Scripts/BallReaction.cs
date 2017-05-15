using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReaction : MonoBehaviour {
	Rigidbody rigidbody;

	[HideInInspector]
	public static int collectedStars = 3;
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

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Collectible")
		{
			CollectStar(other.gameObject);
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

	void CollectStar(GameObject star)
	{
		collectedStars -= 1;
		star.SetActive(false);
	}
}
