﻿using UnityEngine;
using System.Collections;

public class ImageZoomer : MonoBehaviour {
	public GameObject user;
	public float speed = 5f;

	Transform imageOriginalPosition;

	// Use this for initialization
	void Start () {
	
	}
	
// Update is called once per frame
	void Update () {
	
	}

	public void ZoomImage()
	{
		imageOriginalPosition = transform;
		Vector3 imageDestination = user.transform.position + (Vector3.forward * 3);
		transform.position = Vector3.Lerp(transform.position, imageDestination, Time.deltaTime * speed);
		transform.LookAt(user.transform);
		transform.Rotate(new Vector3(0, 180, 0));
	}
}
