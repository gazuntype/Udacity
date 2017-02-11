using UnityEngine;
using System.Collections;

public class ImageZoomer : MonoBehaviour {
	public GameObject user;
	public float speed = 10f;
	Vector3 imageDestination;

	bool zoom;
	bool isZoomedIn;
	Vector3 imageOriginalPosition;

	// Use this for initialization
	void Start () {
	
	}
	
// Update is called once per frame
	void Update () {
		if (zoom)
		{
			transform.position = Vector3.Lerp(transform.position, imageDestination, Time.deltaTime * speed);
			if (transform.position == imageDestination)
			{
				zoom = false;
			}
		}
	}

	public void ZoomImage()
	{
		if (!isZoomedIn)
		{
			imageOriginalPosition = transform.position;
			imageDestination = user.transform.position + (Vector3.forward * -3) - (Vector3.up);
			transform.SetAsLastSibling();
			isZoomedIn = true;
			zoom = true;
		}
		else {
			imageDestination = imageOriginalPosition;
			isZoomedIn = false;
			zoom = true;
		}
	}

}
