using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	public static void SavePlayer(TimeCounter timer)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.cubes";
		FileStream stream = new FileStream(path, FileMode.Create);

		TimeData data = new TimeData(timer);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static TimeData LoadPlayer()
	{
		string path = Application.persistentDataPath + "/player.cubes";

		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			TimeData data = formatter.Deserialize(stream) as TimeData;
			stream.Close();
			return data;
		}
		else
		{
			Debug.LogError("SAVE FILE NOT FOUND IN " + path);
			return null;
		}
	}
}
