using UnityEngine;
using System.Collections;

public class VoiceControl : MonoBehaviour {
	public AudioClip[] audioClip;

	GvrAudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<GvrAudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (UIControl.playClicked)
		{
			switch (UIControl.currentUserState)
			{
				case UIControl.UserState.title:
					if (audioSource.isPlaying)
					{
						audioSource.Stop();
					}
					audioSource.PlayOneShot(audioClip[0]);
					break;
				case UIControl.UserState.introduction:
					if (audioSource.isPlaying)
					{
						audioSource.Stop();
					}
					audioSource.PlayOneShot(audioClip[1]);
					break;
				case UIControl.UserState.station1:
					if (audioSource.isPlaying)
					{
						audioSource.Stop();
					}
					audioSource.PlayOneShot(audioClip[2]);
					break;
				case UIControl.UserState.station2:
					if (audioSource.isPlaying)
					{
						audioSource.Stop();
					}
					audioSource.PlayOneShot(audioClip[3]);
					break;
				case UIControl.UserState.station3:
					if (audioSource.isPlaying)
					{
						audioSource.Stop();
					}
					audioSource.PlayOneShot(audioClip[4]);
					break;
				case UIControl.UserState.station4:
					if (audioSource.isPlaying)
					{
						audioSource.Stop();
					}
					audioSource.PlayOneShot(audioClip[5]);
					break;
				case UIControl.UserState.station5:
					if (audioSource.isPlaying)
					{
						audioSource.Stop();
					}
					audioSource.PlayOneShot(audioClip[6]);
					break;
			}
		}
	}
}
