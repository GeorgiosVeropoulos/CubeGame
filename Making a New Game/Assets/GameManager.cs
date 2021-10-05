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

		LoadData();
		times[1] = mydata.Timer1;
		times[2] = mydata.Timer2;
		times[3] = mydata.Timer3;
		times[4] = mydata.Timer4;
		Debug.Log("times1 = " + mydata.Timer1);

	}
	private void OnApplicationQuit()
	{
		Debug.Log("Application quitting");
		
		SaveData();
		
	}

	void SaveData()
	{
		FileStream file = null;

		try
		{
			BinaryFormatter bf = new BinaryFormatter();

			file = File.Create(Application.persistentDataPath + Data_Path);

			LevelData data = new LevelData(times[1], times[2], times[3], times[4]);
			
			bf.Serialize(file, data);
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

	void LoadData()
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
