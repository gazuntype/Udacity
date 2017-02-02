using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {
	public Text title;
	public Text subTitle;
	public Text hint;
	public Text body;
	public Button play;
	public Button move;

	enum UserState { title, instructions, introduction }

	private UserState currentUserState;
	private float hintTimer = 6f;
	// Use this for initialization
	void Start () {
		currentUserState = UserState.title;
		StartCoroutine(DisplayHint());
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Play()
	{
		switch (currentUserState)
		{
			case UserState.title:
				currentUserState = UserState.instructions;
				title.text = "INSTRUCTIONS";
				subTitle.text = "Buttons and their uses";
				body.gameObject.SetActive(true);
				hint.text = "Look at the button and click";
				hint.gameObject.SetActive(false);
				play.gameObject.transform.localPosition -= new Vector3(0,90,0);
				StopCoroutine(DisplayHint());
				StartCoroutine(DisplayHint());
				break;
			case UserState.instructions:
				currentUserState = UserState.introduction;
				title.text = "INTRODUCTION";
				subTitle.text = "Be amazed.";
				body.transform.GetChild(0).gameObject.SetActive(false);
				body.lineSpacing = 1;
				body.text = "Hello! This is a simple VR experience to showcase the application of virtual reality to amusement parks." +
					" Companies like VRCoaster have made it their goal to cleverly integrate virtual reality in rides like rollercoasters and haunted house. Click the GO button and let's begin!";
				hint.text = "Click the sound button to activate voice over";
				hint.gameObject.SetActive(false);
				StopCoroutine(DisplayHint());
				StartCoroutine(DisplayHint());
				break;
		}
	}


	public void GazeOnButton()
	{
		Image buttonImage;
		buttonImage = play.gameObject.GetComponent<Image>();
		buttonImage.color = Color.green;
	}

	public void GazeOffButton()
	{
		Image buttonImage;
		buttonImage = play.gameObject.GetComponent<Image>();
		buttonImage.color = Color.white;
	}

	IEnumerator DisplayHint()
	{
		while (!hint.gameObject.activeSelf)
		{
			yield return new WaitForSeconds(hintTimer);
			hint.gameObject.SetActive(true);
		}
	}
}
