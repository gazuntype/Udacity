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

	public GameObject gallery;

	public Image bigImage;

	public Text title;
	public Text subTitle;

	enum SpriteIndex { medicine, game, tourism, vrcoaster, sixFlags, cedarPoint, europaPark };

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
		images[SpriteIndex.cedarPoint] = sprites[4];
		images[SpriteIndex.europaPark] = sprites[5];
		images[SpriteIndex.sixFlags] = sprites[6];
	}

	IEnumerator ImageChange()
	{
		while (true)
		{
			if (UIControl.playClicked)
			{
				switch (UIControl.currentUserState)
				{
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
						title.gameObject.SetActive(false);
						subTitle.gameObject.SetActive(false);
						foreach (Image imageIndex in imageObjects)
						{
							imageIndex.gameObject.SetActive(false);
						}
						bigImage.gameObject.SetActive(true);
						bigImage.sprite = images[SpriteIndex.vrcoaster];
						break;
					case UIControl.UserState.station3:
						title.gameObject.SetActive(true);
						subTitle.gameObject.SetActive(true);
						bigImage.gameObject.SetActive(false);
						foreach (Image imageIndex in imageObjects)
						{
							imageIndex.gameObject.SetActive(true);
						}
						imageObjects[0].sprite = images[SpriteIndex.cedarPoint];
						imageObjects[1].sprite = images[SpriteIndex.sixFlags];
						imageObjects[2].sprite = images[SpriteIndex.europaPark];
						break;
					case UIControl.UserState.station4:
						foreach (Image imageIndex in imageObjects)
						{
							imageIndex.gameObject.SetActive(false);
						}
						gallery.SetActive(true);
						break;
				}
				UIControl.playClicked = false;
			}
			yield return new WaitForSeconds(1f);
		}
	}
}
