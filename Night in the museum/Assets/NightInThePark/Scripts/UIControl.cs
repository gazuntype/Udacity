using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {
	public Text title;
	public Text subTitle;
	public Text hint;
	public Text body;
	public Button play;

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
