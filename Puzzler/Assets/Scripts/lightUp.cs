using UnityEngine;
using System.Collections;

public class lightUp : MonoBehaviour {
	public Material lightUpMaterial;
	private Material defaultMaterial;
	GvrAudioSource audioSource;
	public int orbNumber;
	public static int count = 0;
	public static bool show = true;

	// Use this for initialization
	void Start () {
		defaultMaterial = this.GetComponent<MeshRenderer> ().material;
		audioSource = GetComponent<GvrAudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerMovement.init)
		{
			PlayerMovement.init = false;
			count = 1;
		}
		if (orbNumber == count && show)
		{
			patternLightUp(2);
			show = false;
		}
	
	}
	void patternLightUp(float duration) { //The lightup behavior when displaying the pattern
		StartCoroutine(lightFor(duration));
	}


	void gazeLightUp() {
		this.GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
		audioSource.Play();

		//gameLogic.GetComponent<gameLogic>().playerSelection(this.gameObject);


	}
	void playerSelection() {
		//GameLogic.GetComponent<gameLogic>().playerSelection(this.gameObject);
		//audioSource.Play();
	}
	void aestheticReset() {
		this.GetComponent<MeshRenderer>().material = defaultMaterial; //Revert to the default material
	}

	void patternLightUp() { //Lightup behavior when the pattern shows.
		this.GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
		audioSource.Play (); //Play the audio attached
	}


	IEnumerator lightFor(float duration) { //Light us up for a duration.  Used during the pattern display
		patternLightUp ();
		yield return new WaitForSeconds(duration-.1f);
		aestheticReset ();
		count++;
		show = true;
	}
}
