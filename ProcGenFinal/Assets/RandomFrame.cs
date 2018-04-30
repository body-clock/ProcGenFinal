using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RandomFrame : MonoBehaviour
{

	public VideoPlayer vp;

	void Awake()
	{
		vp = GetComponent<VideoPlayer>();
	}

	void ChooseRandomFrame()
	{
		vp.frame = (long)Random.Range(0, vp.frameCount);
		//vp.frame = 10;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("attempt");
			ChooseRandomFrame();
		}
	}
}
