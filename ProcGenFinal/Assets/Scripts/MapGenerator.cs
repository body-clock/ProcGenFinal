﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	
	public enum DrawMode 
	{
		NoiseMap, ColorMap, Mesh
	}

	public DrawMode drawMode;

	//width and height of our map
	public int mapWidth;
	public int mapHeight;
	public float noiseScale;
	
	public bool autoUpdate;

	public TerrainType[] regions;

	public int octaves;
	[Range(0,1)]
	public float persistance;
	public float lacunarity;

	public int seed;
	public Vector2 offset;

	public float meshHeightMultiplier;
	public AnimationCurve meshHeightCurve;

	public void GenerateMap()
	{
		float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

		Color[] colorMap = new Color[mapWidth * mapHeight];
		
		//looping through our map
		for (int y = 0; y < mapHeight; y++)
		{
			for (int x = 0; x < mapWidth; x++)
			{
				float CurrentHeight = noiseMap[x, y];
				for (int i = 0; i < regions.Length; i++)
				{
					//setting our colors to the ones we chose from image
					regions[i].color = ColorPicker.instance.colors[i];
					
					if (CurrentHeight<= regions[i].height)
					{
						colorMap[y * mapWidth + x] = regions[i].color;
						break;
					}
				}
			}

		}

		MapDisplay display = FindObjectOfType<MapDisplay>();

		//generating based on our drawmode
		if (drawMode == DrawMode.NoiseMap)
		{
			display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));

		} else if (drawMode == DrawMode.ColorMap)
		{
			display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
		} else if (drawMode == DrawMode.Mesh)
		{
			display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve),
				TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
		}
	}

	void OnValidate()
	{
		//value boundaries
		if (mapWidth < 1)
		{
			mapWidth = 1;
		}

		if (mapHeight < 1)
		{
			mapHeight = 1;
		}

		if (lacunarity < 1)
		{
			lacunarity = 1;
		}

		if (octaves < 0)
		{
			octaves = 0;
		}	
	}
}

[System.Serializable]
public struct TerrainType
{
	//custom constructor so we can define these values in the inspector
	public string name;
	public float height;
	public Color color;
}
