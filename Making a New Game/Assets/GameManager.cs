using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class GameManager : MonoBehaviour
{
	private static GameManager s_Instance = null;

	
	
	public float[] times;
	public void Awake()
	{

		


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
	public void Update()
	{
		
	}
	

}
