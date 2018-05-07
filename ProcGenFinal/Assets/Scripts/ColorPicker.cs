using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour {

	//input photo
	//cycle through each pixel in the photo
	//pick 5 random colors and put them into an array
	//set colors in our mapgen script

	public Texture2D image;

	public Color[] colors = new Color[4];

	private MapGenerator mapGen;

	//singleton pattern so we can access the values from our map gen
	public static ColorPicker instance;

	public void PickColors()
	{
		//populate our array
		Debug.Log(Random.Range(0, image.width));
		colors[0] = image.GetPixel(Random.Range(0, image.width), Random.Range(0, image.height));
		colors[1] = image.GetPixel(Random.Range(0, image.width), Random.Range(0, image.height));
		colors[2] = image.GetPixel(Random.Range(0, image.width), Random.Range(0, image.height));
		colors[3] = image.GetPixel(Random.Range(0, image.width), Random.Range(0, image.height));
		colors[4] = image.GetPixel(Random.Range(0, image.width), Random.Range(0, image.height));
	}

	void Start()
	{
		PickColors();
		instance = this;
	}

}
