using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenu : MonoBehaviour {

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
}
