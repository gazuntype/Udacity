using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonGreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GazeOnButton()
	{
		Image buttonImage;
		buttonImage = GetComponent<Image>();
		buttonImage.color = Color.green;
	}

	public void GazeOffButton()
	{
		Image buttonImage;
		buttonImage = GetComponent<Image>();
		buttonImage.color = Color.white;
	}
}
