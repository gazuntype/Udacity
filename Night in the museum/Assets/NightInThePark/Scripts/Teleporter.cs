using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	[Tooltip("The different positions the user would be teleported to in order")]
	public Transform[] wayPoints;

	public GameObject canvas;

	[Tooltip("The speed of teleportation")]
	public float speed = 10f;

	[Tooltip("The height of the user")]
	public float height = 1.75f;

	int wayPointIndex = 0;
	GvrViewer viewer;

	// Use this for initialization
	void Start () {
		wayPointIndex = 0;
		viewer = GameObject.Find("GvrViewerMain").GetComponent<GvrViewer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (UIControl.moveClicked)
		{
			wayPointIndex = (wayPointIndex + 1) % wayPoints.Length;
			Vector3 canvasDestination = wayPoints[wayPointIndex].position + (Vector3.up * height) + (Vector3.forward * 7);
			canvas.transform.position = canvasDestination;
			UIControl.moveClicked = false;
		}
		Vector3 destination = wayPoints[wayPointIndex].position + (Vector3.up * height);
		transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * speed);
	}
}
