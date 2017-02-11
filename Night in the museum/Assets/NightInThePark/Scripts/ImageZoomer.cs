using UnityEngine;
using System.Collections;

public class ImageZoomer : MonoBehaviour {
	public GameObject user;
	public float speed = 10f;

	bool zoom;
	Transform imageOriginalPosition;

	// Use this for initialization
	void Start () {
	
	}
	
// Update is called once per frame
	void Update () {
		if (zoom)
		{
			Vector3 imageDestination = user.transform.position + (Vector3.forward * -3) - (Vector3.up);
			transform.position = Vector3.Lerp(transform.position, imageDestination, Time.deltaTime * speed);
			if (transform.position == imageDestination)
			{
				zoom = false;
			}
		}
	}

	public void ZoomImage()
	{
		imageOriginalPosition = transform;
		transform.SetAsLastSibling();
		zoom = true;
	}
}
