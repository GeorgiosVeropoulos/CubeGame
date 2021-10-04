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
		Debug.Log("Time DATA SCRIPT   " + timer.IndexofScene);
		level[timer.IndexofScene] = timer.IndexofScene;
		Debug.Log("Time DATA SCRIPT LEVEL   " + level[timer.IndexofScene]);
		Timer[timer.IndexofScene] = timer.TimeofLevel;
		//Timer[] = timer.TimeofLevel;
		//if (level == 1)
		//{
		//	Timer[1] = timer.TimeofLevel;
		//	//Timer1 = Timer;

		//}
		//if (level == 2)
		//{
		//	Timer[2] = timer.TimeofLevel;
		//	//Timer2 = Timer;

		//}
		//if (level == 3)
		//{
		//	Timer[3] = timer.TimeofLevel;
		//	//Timer3 = Timer;

		//}
		//if (level == 4)
		//{
		//	Timer[4] = timer.TimeofLevel;
		//	//Timer4 = Timer;

		//}
	}
}
