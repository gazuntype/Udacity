using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
	public GameObject keyPoof;
	public GameObject door;
	bool hasKey = false;
	Door doorScript;

	void Start()
	{
		doorScript = door.GetComponent<Door>();
	}
    //Create a reference to the KeyPoofPrefab and Door

	void Update()
	{
		transform.Rotate(0, 0, 1);
	}

	public void OnKeyClicked()
	{
		GameObject poof = (GameObject)Instantiate(keyPoof, transform.position, Quaternion.identity);
		poof.transform.Rotate(new Vector3(-90, 0, 0));
		hasKey = true;
		doorScript.Unlock();
		Destroy(gameObject);
    }

}
