using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrowing : MonoBehaviour {
	[Tooltip("The default force of the throw")]
	[Range(0, 10)]
	public float throwForce = 1.5f;

	private GameObject middleText;

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device VRDevice;

	[HideInInspector]
	public static bool inTheAir;
	[HideInInspector]
	public static string thrownObject;

	// Use this for initialization
	void Start () {
		middleText = GameObject.Find("MiddleText");
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		VRDevice = SteamVR_Controller.Input((int)trackedObject.index);
		if (VRDevice.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)){
			FreezeObjectInAir();
		}
	}


	void OnTriggerStay(Collider other)
	{
		Rigidbody objectRigidbody;
		objectRigidbody = other.gameObject.GetComponent<Rigidbody>();
		if (VRDevice.GetPressDown(SteamVR_Controller.ButtonMask.Grip) && other.tag == "Throwable")
		{
			other.transform.SetParent(transform);
			inTheAir = false;
			if (!objectRigidbody.useGravity)
			{
				objectRigidbody.useGravity = true;
			}
			objectRigidbody.isKinematic = true;
			if (thrownObject != other.name)
			{
				thrownObject = other.name;
			}
			VRDevice.TriggerHapticPulse(2000);
		}
		else if (VRDevice.GetPressUp(SteamVR_Controller.ButtonMask.Grip) && other.tag == "Throwable")
		{
			other.transform.SetParent(null);
			objectRigidbody.isKinematic = false;
			objectRigidbody.velocity = VRDevice.velocity * throwForce;
			objectRigidbody.angularVelocity = VRDevice.angularVelocity;
			if (!inTheAir)
			{
				inTheAir = true;
				Debug.Log(inTheAir);
			}
		}

		if (other.name == "Next")
		{
			VRDevice.TriggerHapticPulse(2000);
			if (VRDevice.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
			{
				middleText.GetComponent<Instruction>().NextInstruction();
			}
		}
		else if (other.name == "Back")
		{
			VRDevice.TriggerHapticPulse(2000);
			if (VRDevice.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
			{
				middleText.GetComponent<Instruction>().PreviousInstruction();
			}
		}
	}

	void FreezeObjectInAir()
	{
		if (inTheAir)
		{
			GameObject freezeObject = GameObject.Find(thrownObject);
			Rigidbody freezeRB = freezeObject.GetComponent<Rigidbody>();
			freezeObject.layer = 9;
			freezeRB.useGravity = false;
			freezeRB.velocity = Vector3.zero;
			freezeRB.angularVelocity = Vector3.zero;
		}
	}

}
