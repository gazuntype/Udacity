using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenu : MonoBehaviour {


	[Tooltip("The prefabs of the various unique objects used for level 1 of the challenge")]
	public List<GameObject> uniquePrefab;

	[Tooltip("The GameObjects of the menu options.")]
	public List<GameObject> uniqueObject;

	public GameObject objectMenu;


	private int menuIndex = 0;
	private bool isMenuOpen;
	private bool hasSwipedRight, hasSwipedLeft;

	private float touchCurrent, touchLast, distance, swipeSum;

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device VRDevice;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		VRDevice = SteamVR_Controller.Input((int)trackedObject.index);
		if (VRDevice.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
		{
			touchLast = VRDevice.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
		}
		if (VRDevice.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
		{
			Debug.Log("Touchpad was pressed");
			if (!isMenuOpen)
			{
				SpawnMenu();
				isMenuOpen = true;
			}
			CheckSwipeDistance();
			if (!hasSwipedRight)
			{
				if (swipeSum > 0.5f)
				{
					swipeSum = 0;
					SwipeRight();
					hasSwipedLeft = false;
					hasSwipedRight = true;
				}
			}

			if (!hasSwipedLeft)
			{
				if (swipeSum < -0.5f)
				{
					swipeSum = 0;
					SwipeLeft();
					hasSwipedRight = false;
					hasSwipedLeft = true;
				}
			}
		}

		if (VRDevice.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
		{
			distance = 0;
			hasSwipedLeft = false;
			hasSwipedRight = false;
			touchLast = 0;
			touchCurrent = 0;
			swipeSum = 0;
		}

		if (VRDevice.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			if (isMenuOpen)
			{
				SpawnObject();
			}
		}

	}

	void CheckSwipeDistance()
	{
		touchCurrent = VRDevice.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
		distance = touchCurrent - touchLast;
		touchLast = touchCurrent;
		swipeSum += distance;
	}

	void SpawnMenu()
	{
		objectMenu.SetActive(true);
		foreach (GameObject g in uniqueObject){
			g.SetActive(false);
		}
		uniqueObject[0].SetActive(true);
	}

	void SwipeRight()
	{
		uniqueObject[menuIndex].SetActive(false);
		menuIndex++;
		if (menuIndex > uniqueObject.Count - 1)
		{
			menuIndex = 0;
		}
		uniqueObject[menuIndex].SetActive(true);
	}

	void SwipeLeft()
	{
		uniqueObject[menuIndex].SetActive(false);
		menuIndex--;
		if (menuIndex < 0)
		{
			menuIndex = uniqueObject.Count - 1;
		}
		uniqueObject[menuIndex].SetActive(true);
	}

	void SpawnObject()
	{
		GameObject spawnedObject;
		spawnedObject = Instantiate(uniquePrefab[menuIndex], objectMenu.transform.position, uniqueObject[menuIndex].transform.rotation);
		spawnedObject.transform.localScale = spawnedObject.transform.localScale * 0.5f;
		menuIndex = 0;
		objectMenu.SetActive(false);
		isMenuOpen = false;
	}
}
