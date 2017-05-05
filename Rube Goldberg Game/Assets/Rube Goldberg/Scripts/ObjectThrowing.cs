using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrowing : MonoBehaviour {
	[Tooltip("The default force of the throw")]
	[Range(0, 10)]
	public float throwForce = 1.5f;


	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device VRDevice;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		VRDevice = SteamVR_Controller.Input((int)trackedObject.index);

	}

	void OnTriggerStay(Collider other)
	{
		Debug.Log("Recognised collision");
		Rigidbody objectRigidbody;
		objectRigidbody = other.gameObject.GetComponent<Rigidbody>();
		if (VRDevice.GetPressDown(SteamVR_Controller.ButtonMask.Grip) && other.tag == "Throwable")
		{
			Debug.Log("Recognised it is a ball");
			other.transform.SetParent(transform);
			objectRigidbody.isKinematic = true;
			VRDevice.TriggerHapticPulse(2000);
		}
		else if (VRDevice.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
		{
			other.transform.SetParent(null);
			objectRigidbody.isKinematic = false;
			objectRigidbody.velocity = VRDevice.velocity * throwForce;
			objectRigidbody.angularVelocity = VRDevice.angularVelocity;
		}
	}

}
