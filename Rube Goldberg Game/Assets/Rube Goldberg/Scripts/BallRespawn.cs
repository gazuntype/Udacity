using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour {

	Vector3 initialPosition;
	Rigidbody rigidbody;

	GameObject[] collectible;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		rigidbody = GetComponent<Rigidbody>();
		collectible = GameObject.FindGameObjectsWithTag("Collectible");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "FloorPlane")
		{
			RespawnBall();
			RespawnCollectibles();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Goal")
		{
			if (BallReaction.collectedStars == 0)
			{
				SteamVR_LoadLevel.Begin("secondLevel");
			}
		}
	}

	void RespawnBall()
	{
		transform.position = initialPosition;
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}

	void RespawnCollectibles()
	{
		foreach (GameObject star in collectible)
		{
			if (!star.activeSelf)
			{
				star.SetActive(true);
			}
			BallReaction.collectedStars = 3;
		}
	}
}
