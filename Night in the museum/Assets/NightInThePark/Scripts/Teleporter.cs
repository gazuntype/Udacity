using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
	[Tooltip("The different positions the user would be teleported to in order")]
	public Transform[] wayPoints;

	[Tooltip("The different positions the canvas would be teleported to in order")]
	public Transform[] wayPointsCanvas;

	public GameObject canvas;

	[Tooltip("The speed of teleportation")]
	public float speed = 10f;

	[Tooltip("The height of the user")]
	public float height = 1.75f;

	[Tooltip("The height of the canvas")]
	public float canvasHeight = 2;

	GvrAudioSource audioSource;

	int wayPointIndex = 0;

	// Use this for initialization
	void Start()
	{
		wayPointIndex = 0;
		audioSource = GetComponent<GvrAudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
			if (UIControl.moveClicked)
			{
				audioSource.Play();
				wayPointIndex = (wayPointIndex + 1) % wayPoints.Length;
				Vector3 canvasDestination = wayPointsCanvas[wayPointIndex].position + (Vector3.up * canvasHeight);
				canvas.transform.position = canvasDestination;
				canvas.transform.LookAt(wayPoints[wayPointIndex].position + (Vector3.up * height));
				canvas.transform.Rotate(new Vector3(0, 180, 0));
				canvas.transform.eulerAngles = new Vector3(0, canvas.transform.eulerAngles.y, canvas.transform.eulerAngles.z);
				UIControl.moveClicked = false;
			}
			Vector3 destination = wayPoints[wayPointIndex].position + (Vector3.up * height);
			transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * speed);
			transform.LookAt(wayPointsCanvas[wayPointIndex].position + (Vector3.up * canvasHeight));
	}
}
