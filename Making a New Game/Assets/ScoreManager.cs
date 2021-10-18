using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
	private static ScoreManager s_Instance = null;
	private string Data_Path = "scores.cubes";

	private ScoreData Scoredata;

	public int[] scores;
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


		scores[1] = Scoredata.Score1;
		scores[2] = Scoredata.Score2;
		scores[3] = Scoredata.Score3;
		scores[4] = Scoredata.Score4;
		scores[5] = Scoredata.Score5;
		scores[6] = Scoredata.Score6;
		scores[7] = Scoredata.Score7;
		scores[8] = Scoredata.Score8;
		scores[9] = Scoredata.Score9;
		scores[10] = Scoredata.Score10;
		scores[11] = Scoredata.Score11;
		scores[12] = Scoredata.Score12;
		scores[13] = Scoredata.Score13;
		scores[14] = Scoredata.Score14;
		scores[15] = Scoredata.Score15;
		scores[16] = Scoredata.Score16;

		
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

			
			ScoreData score = new ScoreData(scores[1], scores[2], scores[3], scores[4], scores[5], scores[6], scores[7]
				, scores[8], scores[9], scores[10], scores[11], scores[12], scores[13], scores[14], scores[15], scores[16]);

			
			//this is new
			bf.Serialize(file, score);
		}
		catch (Exception e)
		{
			if (e != null)
			{

			}
		}
		finally
		{
			if (file != null)
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
			
			Scoredata = bf.Deserialize(file) as ScoreData;
		}
		catch (Exception e)
		{

		}
		finally
		{
			if (file != null)
			{
				file.Close();
			}
		}
	}
}

