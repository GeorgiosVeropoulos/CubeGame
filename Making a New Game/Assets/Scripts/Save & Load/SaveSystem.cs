//using System.IO;
//using UnityEngine;
//using System.Runtime.Serialization.Formatters.Binary;


//public static class SaveSystem
//{
	
//	public static void SavePlayer(TimeCounter timer)
//	{
//		// LOAD DATA
		

//		// SAVE 
//		string path = Application.persistentDataPath + "/player.cubes";
		

//		BinaryFormatter formatter = new BinaryFormatter();
//		//FileStream stream = new FileStream(path, FileMode.Create);
//		FileStream streams = File.OpenWrite(path);
		
//		TimeData data = new TimeData(timer);
		

//		formatter.Serialize(streams, data);
		
//		streams.Close();
//	}

//	public static TimeData LoadPlayer()
//	{
//		string path = Application.persistentDataPath + "/player.cubes";

//		if (File.Exists(path))
//		{
//			BinaryFormatter formatter = new BinaryFormatter();
//			//FileStream stream = new FileStream(path, FileMode.Open);
//			FileStream stream = File.OpenRead(path);
//			TimeData data = formatter.Deserialize(stream) as TimeData;
//			stream.Close();
//			return data;
//		}
//		else
//		{
//			Debug.LogError("SAVE FILE NOT FOUND IN " + path);
//			return null;
//		}
//	}
//}
