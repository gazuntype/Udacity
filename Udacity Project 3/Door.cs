using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour 
{
	float speed = 1f;
	bool locked = false;
	bool openGate = false;
	public GameObject signPost;

	// Create a boolean value called "locked" that can be checked in Update() 

    void Update() {
		if (locked && openGate)
		{
			transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 20, 0), Time.deltaTime * speed);
			AudioSource source = GetComponent<AudioSource>();
			source.Play();
			if (transform.position.y > 20)
			{
				GameObject sign = (GameObject)Instantiate(signPost, transform.position - new Vector3(0, 12, 0), Quaternion.identity);
				sign.transform.Rotate(new Vector3(0, 90, 0));
				Destroy(gameObject);
			}
		}

    }


    public void Unlock()
    {
		locked = true;
    }

	public void OpenGate()
	{
		openGate = true;
	}
}
