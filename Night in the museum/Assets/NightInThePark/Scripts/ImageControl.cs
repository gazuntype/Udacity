using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ImageControl : MonoBehaviour {
	[Tooltip("All the images that can be displayed")]
	public Sprite[] sprites;

	Dictionary<SpriteIndex,Sprite> images = new Dictionary<SpriteIndex, Sprite>();

	[Tooltip("Image Objects that display the images")]
	public Image[] imageObjects;

	[Tooltip("Background image")]
	public Image background;

	public Image bigImage;

	public Text title;
	public Text subTitle;

	enum SpriteIndex { medicine, game, tourism, vrcoaster };

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
		images[SpriteIndex.medicine] = sprites[0];
		images[SpriteIndex.game] = sprites[1];
		images[SpriteIndex.tourism] = sprites[2];
		images[SpriteIndex.vrcoaster] = sprites[3];
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
						break;
					case UIControl.UserState.instructions:
						break;
					case UIControl.UserState.introduction:
						break;
					case UIControl.UserState.station1:
						title.gameObject.SetActive(true);
						subTitle.gameObject.SetActive(true);
						background.gameObject.SetActive(true);
						foreach (Image imageIndex in imageObjects)
						{
							imageIndex.gameObject.SetActive(true);
						}
						imageObjects[0].sprite = images[SpriteIndex.medicine];
						imageObjects[1].sprite = images[SpriteIndex.game];
						imageObjects[2].sprite = images[SpriteIndex.tourism];
						break;
					case UIControl.UserState.station2:
						break;
					case UIControl.UserState.station3:
						break;
					case UIControl.UserState.station4:
						break;
				}
				UIControl.playClicked = false;
			}
			yield return new WaitForSeconds(1f);
		}
	}
}
