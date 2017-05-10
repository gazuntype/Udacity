using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableArea : MonoBehaviour {

	private Renderer areaRenderer;
	private Material areaMaterial;
	// Use this for initialization
	void Start () {
		areaRenderer = GetComponent<Renderer>();
		areaMaterial = areaRenderer.material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			
			areaMaterial.color = Color.green;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Player left");
			areaMaterial.color = Color.red;
		}
	}
}
