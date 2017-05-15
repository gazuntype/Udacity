using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLanded : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (name == ObjectThrowing.thrownObject && other.gameObject.name == "FloorPlane")
		{
			Debug.Log(ObjectThrowing.inTheAir);
			ObjectThrowing.inTheAir = false;
		}
	}
}
