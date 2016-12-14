using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public Transform player;
	public Transform initialPoint;
	public Transform finalPoint;
	public static int location = 0;
	public static bool init = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToInitialPoint()
	{
		StartCoroutine(Motion(player.position, initialPoint.position));
		location = 1;
	}

	public void GoToFinalPoint()
	{
		StartCoroutine(Motion(player.position, finalPoint.position));
		location = 2;
	}

	public void RestartScene()
	{
		SceneManager.LoadScene("mainScene");
	}

	IEnumerator Motion(Vector3 iniPos, Vector3 finalPos)
	{
		float timeMove = 0f;
		while (true)
		{
			timeMove += Time.deltaTime;
			transform.position = Vector3.Lerp(iniPos, finalPos, timeMove);
			if (transform.position == finalPos)
			{
				init = true;
				yield break;
			}
			yield return null;
		}
	}
}
