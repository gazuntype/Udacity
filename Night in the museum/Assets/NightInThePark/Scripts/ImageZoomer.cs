using UnityEngine;
using System.Collections;

public class ImageZoomer : MonoBehaviour {
	public GameObject user;
	public float speed = 10f;

	Vector3 imageDestination;
	float lerpConstant = 0f;
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
			transform.position = Vector3.Lerp(transform.position, imageDestination, lerpConstant * speed);
			lerpConstant += 0.01f;
			if (transform.position == imageDestination)
			{
				lerpConstant = 0f;
				zoom = false;
			}
		}
	}

	public void ZoomImage()
	{
		if (!isZoomedIn)
		{
			imageOriginalPosition = transform.position;
			switch (UIControl.currentUserState)
			{
				case UIControl.UserState.station1:
					imageDestination = user.transform.position + (Vector3.forward * -3) - (Vector3.up);
					break;
				case UIControl.UserState.station3:
					imageDestination = user.transform.position + (Vector3.forward * 3) - (Vector3.up);
					break;
				case UIControl.UserState.station4:
					imageDestination = user.transform.position + (Vector3.forward * -3) - (Vector3.right * 2f);
					break;
			}
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
