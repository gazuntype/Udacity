using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ImageControl : MonoBehaviour {
	[Tooltip("All the images that can be displayed")]
	public Sprite[] sprites;

	Dictionary<string,Sprite> images = new Dictionary<string, Sprite>();

	[Tooltip("Image Objects that display the images")]
	public Image[] imageObjects;

	[Tooltip("Background image")]
	public Image Background;

	public Text title;
	public Text subTitle;

	// Use this for initialization
	void Start () {
		SpriteToDictionary();
		StartCoroutine(ImageChange());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpriteToDictionary()
	{
		images["medicine"] = sprites[0];
		images["game"] = sprites[1];
		images["tourism"] = sprites[2];
	}

	IEnumerator ImageChange()
	{
		while (true)
		{
			if (UIControl.playClicked)
			{
				switch (UIControl.currentUserState)
				{
					case UIControl.UserState.title:
						UIControl.currentUserState = UIControl.UserState.instructions;
						break;
					case UIControl.UserState.instructions:
						UIControl.currentUserState = UIControl.UserState.introduction;
						break;
					case UIControl.UserState.introduction:
						UIControl.currentUserState = UIControl.UserState.station1;
						break;
					case UIControl.UserState.station1:
						UIControl.currentUserState = UIControl.UserState.station2;
						break;
					case UIControl.UserState.station2:
						UIControl.currentUserState = UIControl.UserState.station3;
						break;
					case UIControl.UserState.station3:
						UIControl.currentUserState = UIControl.UserState.station4;
						break;
					case UIControl.UserState.station4:
						UIControl.currentUserState = UIControl.UserState.station5;
						break;
				}
				UIControl.playClicked = false;
			}
			yield return new WaitForSeconds(1f);
		}
	}
}
