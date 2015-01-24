﻿using UnityEngine;
using System.Collections;

public class Map01 : MonoBehaviour {

	public GameObject[] m_floor1;
	private int m_map =0;

	private float x = 0;
	private float z = 0;

	public int[][] m_mapArray2 = new int[][]{
		new int[] { 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 7},
		new int[] { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 8},
		new int[] { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 8},
		new int[] { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 8},
		new int[] { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
		new int[] { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
		new int[] { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
		new int[] { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
		new int[] { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
		new int[] { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,10,12,12,12,12,12,12, 5, 5, 5, 5, 5, 5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
		new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,13 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5},
	};

	// Use this for initialization
	void Start () {
		foreach (int[] array in m_mapArray2)
		{
			foreach (int s in array)
			{
				Instantiate(m_floor1[s], new Vector3(x, 0, z), Quaternion.identity);
				x = x + 0.16f;
			}
			x = 0;
			z = z + 0.16f;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void MapCollider (){

	}
}