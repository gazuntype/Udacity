using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfreezeObject : MonoBehaviour
{
	[Tooltip("The line renderer that depicts the laser for choosing and teleportation")]
	public LineRenderer laser;

	[Tooltip("Layer mask of the objects that are frozen")]
	public LayerMask frozen;

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device VRDevice;
	private RaycastHit hit;
	// Use this for initialization
	void Start()
	{
		trackedObject = GetComponent<SteamVR_TrackedObject>();
		laser.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		VRDevice = SteamVR_Controller.Input((int)trackedObject.index);
	}

	void TargetObject()
	{
		if (VRDevice.GetHairTrigger())
		{
			laser.gameObject.SetActive(true);
			laser.SetPosition(0, transform.position);
			laser.SetPosition(1, transform.position + (transform.forward * 15));
			if (Physics.Raycast(transform.position, transform.forward, out hit, 15f, frozen))
			{
				hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
			}
		}
	}

	void Unfreeze()
	{

	}
}
