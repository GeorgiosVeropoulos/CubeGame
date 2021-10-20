using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class SkinManager : MonoBehaviour
{
    public Material SkingToUse;
    public int numbertoHold;


    private static SkinManager s_Instance = null;
    private string Data_Path = "skins.cubes";

    private SkinData SkinData;

    public bool[] skins;
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
		

		skins[1] = SkinData.Skin1;
		Debug.Log(skins[1]);
		skins[2] = SkinData.Skin2;
		skins[3] = SkinData.Skin3;
		skins[4] = SkinData.Skin4;
		skins[5] = SkinData.Skin5;
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


			SkinData _skin = new SkinData(skins[1], skins[2], skins[3], skins[4], skins[5]);


			//this is new
			bf.Serialize(file, _skin);
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

			SkinData = bf.Deserialize(file) as SkinData;
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
