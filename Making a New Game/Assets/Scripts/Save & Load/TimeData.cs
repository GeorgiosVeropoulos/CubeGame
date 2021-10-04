using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimeData
{
	public int[] level =  new int[10];
	public float[] Timer = new float[10];
	
	public TimeData(TimeCounter timer)
	{
		//Timer = new float[10];
		//level = new int[10];
		//Debug.Log("Time DATA SCRIPT   " + timer.IndexofScene);
		level[timer.IndexofScene] = timer.IndexofScene;
		//Debug.Log("Time DATA SCRIPT LEVEL   " + level[timer.IndexofScene]);
		Timer[timer.IndexofScene] = timer.TimeofLevel;
		
		
	}
}
