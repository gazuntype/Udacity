using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
	[Tooltip("The voiceOver audio clips in sequential order")]
	public AudioClip[] voiceOver;

	[HideInInspector]
	public static bool instructionOver;

	public Text middleText;
	public Text leftText;
	public Text rightText;
	public GameObject canvas;

	private int currentIndex = 1;
	private AudioSource audioSource;
	private IEnumerator coroutine;
	private string[] sequentialMessage = new string[9];
	private bool animationComplete;
	// Use this for initialization

	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		AssignStrings();
	}
	void Start()
	{
		leftText.text = "";
		rightText.text = sequentialMessage[1];
		StartCoroutine(AnimateText(0, 3f));
		audioSource.PlayOneShot(voiceOver[0]);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void AssignStrings()
	{
		sequentialMessage[0] = "Welcome to my Rube Goldberg VR game. Here are the instructions.";
		sequentialMessage[1] = "Use the trigger on your left controller to teleport. You can use this to traverse the environment.";
		sequentialMessage[2] = "Hold down the grip on your right controller to pick up objects. \n Objects that can be picked up glow green when touched with the controller.";
		sequentialMessage[3] = "You can freeze objects in the air by pressing the trigger on your right controller after they are thrown. \n This can be used to place objects in strategic locations midair.";
		sequentialMessage[4] = "Unfreeze frozen objects by holding the trigger on the right controller and pointing at the objects. \n Frozen objects glow green when the right controller is pointed at them with the trigger held.";
		sequentialMessage[5] = "You can spawn different objects to help you complete the challenge. To spawn an object, open up the object menu by touching the touchpad on the right controller.";
		sequentialMessage[6] = "Scroll through the object menu by swiping left or right on the touchpad. This takes you through a selection of objects that can be spawn by clicking the right trigger.";
		sequentialMessage[7] = "Now that you know the control, these are the rules. The aim is to throw the ball and ensure it touches all the stars and lands in the goal wihtout it touching the floor. Use the objects in your object menu to achieve this. \n" +
			"You cannot freeze the ball. \n You must throw the ball within the play area. \n Goodluck! \n Hint: Teleporter teleports ball to teleport pad.";
		sequentialMessage[8] = "";
	}

	IEnumerator AnimateText(int index, float animationTime)
	{
		animationComplete = false;
		middleText.text = "";
		for (int i = 0; i < sequentialMessage[index].Length; i++)
		{
			if (i == 0)
			{
				middleText.text = (sequentialMessage[index])[i].ToString();
			}
			else
			{
				middleText.text += (sequentialMessage[index])[i];
			}
			yield return new WaitForSeconds(animationTime / sequentialMessage[index].Length);
		}
		animationComplete = true;	}

	public void NextInstruction()
	{
		if (animationComplete)
		{
			if (currentIndex <= 7)
			{
				leftText.text = sequentialMessage[currentIndex - 1];
				rightText.text = sequentialMessage[currentIndex + 1];
				StartCoroutine(AnimateText(currentIndex, 2));
				audioSource.Stop();
				audioSource.PlayOneShot(voiceOver[currentIndex]);
				currentIndex += 1;
			}
			else
			{
				canvas.SetActive(false);
				instructionOver = true;
			}
		}
	}

	public void PreviousInstruction()
	{
		if (animationComplete)
		{
			if (currentIndex > 1)
			{
				currentIndex -= 1;
				if (currentIndex - 1 >= 0)
				{
					leftText.text = sequentialMessage[currentIndex - 1];
				}
				else
				{
					leftText.text = "";
				}
				rightText.text = sequentialMessage[currentIndex + 1];
				StartCoroutine(AnimateText(currentIndex, 2));
				audioSource.Stop();
				audioSource.PlayOneShot(voiceOver[currentIndex]);
			}
		}	}
}
