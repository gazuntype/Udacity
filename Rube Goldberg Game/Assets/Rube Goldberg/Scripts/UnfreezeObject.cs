using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnfreezeObject : MonoBehaviour
{
	[Tooltip("The line renderer that depicts the laser for choosing and teleportation")]
	public LineRenderer laser;

	[Tooltip("Layer mask of the objects that are frozen")]
	public LayerMask frozen;

	public LayerMask ui;

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device VRDevice;
	private RaycastHit hit, hitUI;
	private GameObject hitObject = null;
	private GameObject hitButton = null;
	private bool targetedFrozen, targetedUI;
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
		if (VRDevice.GetHairTrigger())
		{
			TargetObject();	
		}
		if (VRDevice.GetHairTriggerUp())
		{
			laser.gameObject.SetActive(false);
			if (targetedFrozen)
			{
				Debug.Log("Something should unfreeze");
				Unfreeze();
			}
			if (targetedUI)
			{
				if (hitButton.name == "Next")
				{
					GameObject.Find("MiddleText").GetComponent<Instruction>().NextInstruction();
				}
				else if (hitButton.name == "Back")
				{
					GameObject.Find("MiddleText").GetComponent<Instruction>().PreviousInstruction();
				}
			}
		}
	}

	void TargetObject()
	{
		laser.gameObject.SetActive(true);
		laser.SetPosition(0, transform.position);
		laser.SetPosition(1, transform.position + (transform.forward * 15));
		if (Physics.Raycast(transform.position, transform.forward, out hit, 15f, frozen))
		{
			hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
			hitObject = hit.collider.gameObject;
			targetedFrozen = true;
		}
		else
		{
			if (hitObject != null)
			{
				hitObject.GetComponent<Renderer>().material.color = Color.white;
				targetedFrozen = false;
			}
		}

		if (Physics.Raycast(transform.position, transform.forward, out hitUI, 15f, ui))
		{
			if (hitUI.collider.gameObject.tag == "button")
			{
				VRDevice.TriggerHapticPulse(2000);
				hitUI.collider.gameObject.GetComponent<Image>().color = Color.green;
				hitButton = hitUI.collider.gameObject;
				targetedUI = true;
			}
		}
		else
		{
			if (hitButton != null && hitButton.tag == "button")
			{
				hitButton.GetComponent<Image>().color = Color.black;
				targetedUI = false;
			}
		}
	}

	void Unfreeze()
	{
		Debug.Log(hitObject.ToString());
		hitObject.GetComponent<Rigidbody>().isKinematic = false;
		hitObject.GetComponent<Rigidbody>().useGravity = true;
	}
}
