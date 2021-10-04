//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;


//[System.Serializable]
//public class GameManager : MonoBehaviour
//{
//    private static GameManager s_Instance = null;
//    [SerializeField]
//    public float[] timers = new float[10];
//    public float timer;
//    public int Level;
//    public void Awake()
//    {
       
//        Level = SceneManager.GetActiveScene().buildIndex;
//        if (s_Instance == null)
//        {
//            s_Instance = this;
//            DontDestroyOnLoad(gameObject);

//            //Initialization code goes here[/INDENT]
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }
//	public void Update()
//	{
//        timer = FindObjectOfType<TimeCounter>().TimeofLevel;

//        if (timer != 0)
//		{
            
            
//		}
//	}
//}
