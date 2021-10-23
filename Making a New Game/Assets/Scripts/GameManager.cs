using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class GameManager : MonoBehaviour
{
	private static GameManager s_Instance = null;
	private string Data_Path = "Cubes.cubes";
	private LevelData mydata;
	
	public float[] times;
	
	public void Awake()
	{
		
		
		//Debug.Log("DATA PATH IS " + Application.persistentDataPath + Data_Path);

		if (s_Instance == null)
		{
			s_Instance = this;
			DontDestroyOnLoad(gameObject);

			//Initialization code goes here[/INDENT]
		}
		else
		{
			Destroy(gameObject);
		}
	}
	private void Start()
	{
		//Application.targetFrameRate = 60;
		LoadData();
		times[1] = mydata.Timer1;
		times[2] = mydata.Timer2;
		times[3] = mydata.Timer3;
		times[4] = mydata.Timer4;
		times[5] = mydata.Timer5;
		times[6] = mydata.Timer6;
		times[7] = mydata.Timer7;
		times[8] = mydata.Timer8;
		times[9] = mydata.Timer9;
		times[10] = mydata.Timer10;
		times[11] = mydata.Timer11;
		times[12] = mydata.Timer12;
		times[13] = mydata.Timer13;
		times[14] = mydata.Timer14;
		times[15] = mydata.Timer15;
		times[16] = mydata.Timer16;
		times[17] = mydata.Timer17;


	}
	private void OnApplicationQuit()
	{
		Debug.Log("Application quitting");
		
		SaveData();
		
	}
	

	
	public void SaveData()
	{
		FileStream file = null;

		try
		{
			BinaryFormatter bf = new BinaryFormatter();

			file = File.Create(Application.persistentDataPath + Data_Path);

			LevelData data = new LevelData(times[1], times[2], times[3], times[4], times[5], times[6], times[7]
				, times[8], times[9], times[10], times[11], times[12], times[13], times[14], times[15], times[16]
				, times[17]);
			

			bf.Serialize(file, data);
			//this is new
			
		}
		catch (Exception e)
		{
			if(e != null)
			{
				
			}
		}
		finally
		{
			if(file != null)
			{
				file.Close();
			}
		}
	}

	public void LoadData()
	{
		FileStream file = null;

		try
		{
			BinaryFormatter bf = new BinaryFormatter();

			file = File.Open(Application.persistentDataPath + Data_Path, FileMode.Open);
			mydata = bf.Deserialize(file) as LevelData;
			
		}
		catch (Exception e)
		{

		}
		finally
		{
			if(file!= null)
			{
				file.Close();
			}
		}
	}
}
