using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {
	public Text title;
	public Text subTitle;
	public Text hint;
	public Button play;

	enum UserState { title, instructions, introduction }

	private UserState currentUserState;
	private float hintTimer = 5f;
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
				hint.text = "I like this booty";
				hint.gameObject.SetActive(false);
				StopCoroutine(DisplayHint());
				StartCoroutine(DisplayHint());
				break;
		}
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
