using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
public static class SaveManager
{

	public static string directory = "SaveData";
	public static string fileName = "MySave.txt";

	public static void Save(TimeData data)
	{
		if (!DirectoryExists())
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/" + directory);
		}
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(GetFullPath());
		bf.Serialize(file, data);
		file.Close();
	}
	public static TimeData Load()
	{
		if (SaveExists())
		{
			try
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(GetFullPath(), FileMode.Open);
				TimeData data = (TimeData)bf.Deserialize(file);
				file.Close();

				return data;
			}
			catch (SerializationException)
			{
				Debug.Log("Failed to load file");
			}
		}
		return null;
	}

	private static bool SaveExists()
	{
		return File.Exists(GetFullPath());
	}
	private static bool DirectoryExists()
	{
		return Directory.Exists(Application.persistentDataPath + "/" + directory);
	}
	private static string GetFullPath()
	{
		return Application.persistentDataPath + "/" + directory + "/" + fileName;
	}
}
