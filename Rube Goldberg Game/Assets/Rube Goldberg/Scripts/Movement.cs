using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	[Tooltip("The line renderer that depicts the laser for choosing and teleportation")]
	public LineRenderer laser;

	[Tooltip("Layer mask of the places that are traversable")]
	public LayerMask walkable;

	[Tooltip("The game object that represents where the user will teleport to")]
	public GameObject teleportLocator;

	public GameObject player;

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device VRDevice;
	private RaycastHit hit;

	private Vector3 teleportLocation;
	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
		laser.gameObject.SetActive(false);
		teleportLocator.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		VRDevice = SteamVR_Controller.Input((int)trackedObject.index);
		if (VRDevice.GetHairTrigger())
		{
			Target();
		}
		else if (VRDevice.GetHairTriggerUp())
		{
			Teleport();
		}
	}

	void Target()
	{
		if (Physics.Raycast(transform.position, transform.forward, out hit, 15f, walkable))
		{
			laser.gameObject.SetActive(true);
			teleportLocator.SetActive(true);
			laser.SetPosition(0, transform.position);
			teleportLocation = hit.point;
			laser.SetPosition(1, teleportLocation);
			teleportLocator.transform.position = teleportLocation;
		}
		else if (Physics.Raycast(transform.position + (new Vector3(transform.forward.x, 0, transform.forward.z) * 15), Vector3.down, out hit, 15f, walkable))
		{
			laser.gameObject.SetActive(true);
			teleportLocator.SetActive(true);
			laser.SetPosition(0, transform.position);
			teleportLocation = hit.point;
			laser.SetPosition(1, teleportLocation);
			teleportLocator.transform.position = teleportLocation;
		}
	}

	void Teleport()
	{
		laser.gameObject.SetActive(false);
		teleportLocator.SetActive(false);
		player.transform.position = new Vector3(teleportLocation.x, player.transform.position.y, teleportLocation.z);
	}
}
