using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public float timer;
    [SerializeField]
    public float TimeofLevel;
    [SerializeField]
    public float TimeofFinish;
    public GameObject txtmeshtext;
    
    public GameObject TimeTopLeft;
    public GameObject Timer;

    public GameObject PauseMenu;
    public GameObject EndScreenTimer;
    public GameObject manager;
    public int IndexofScene;
    public int Level;
	// private TextMesh theTextmesh;
	public void Awake()
	{
        IndexofScene = SceneManager.GetActiveScene().buildIndex;
        Level = IndexofScene;
        Load();
    }

	void Start()
    {
        Debug.Log("Index of scene is " + IndexofScene);
        
        
        TimeTopLeft.SetActive(true);
        Timer.SetActive(true);
        PauseMenu.SetActive(false);
        EndScreenTimer.SetActive(false);
        manager = GameObject.FindGameObjectWithTag("GameManager");
        
       // theTextmesh = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.GetComponent<LevelManager>().CurrentCubesKilled == manager.GetComponent<LevelManager>().CubesToKill)
        {
            TimeofLevel = timer;
            
            EndScreenTimer.GetComponent<TextMeshProUGUI>().text = "Your Time was:  " + TimeofLevel.ToString();
            TimeTopLeft.SetActive(false);
            Timer.SetActive(false);
            
            EndScreenTimer.SetActive(true);
            //SaveSystem.SavePlayer(this);
            Save();
            //SavingandLoading();
        }
        if(Time.timeScale == 1)
		{
            timer += Time.deltaTime;

            
            txtmeshtext.GetComponent<TextMeshProUGUI>().text = "" + timer.ToString();
        }

		if (Input.GetKey(KeyCode.Q))
		{
            //TimeData data = SaveSystem.LoadPlayer();

            //IndexofScene = data.level;
            //TimeofLevel = data.Timer;

		}

        //theTextmesh.text = "" + timer.ToString();
    }
    
    public void LoadNextScene()
	{
        SceneManager.LoadScene(IndexofScene + 1);
	}
    public void LoadPrevious()
	{
        int previouscene = IndexofScene - 1;
        
        if(previouscene == -1)
		{
            // TO DO when i make a main menu
            Debug.Log("main menu hasn't been made yet loading scene index 0 instead");
            SceneManager.LoadScene(0);
        }
		else
		{
            SceneManager.LoadScene(previouscene);
		}
	}
    public void SavingandLoading()
	{
  //      if(SaveSystem.LoadPlayer() != null)
		//{
  //          TimeData data = SaveSystem.LoadPlayer();

  //          IndexofScene = data.level;
  //          TimeofLevel = data.Timer;
  //          Debug.Log(TimeofLevel);
  //          Debug.Log(IndexofScene);
  //          if(timer <= TimeofLevel)
		//	{
  //              SaveSystem.SavePlayer(this);
                
  //              Debug.Log("Best time is " + data.Timer);
  //          }
		//	else
		//	{

		//	}
  //      }
		//else
		//{
  //          SaveSystem.SavePlayer(this);
  //          Debug.Log("HERE");
		//}
	}
	public void Save()
	{
		SaveSystem.SavePlayer(this);

	}
	public void Load()
	{
        if (SaveSystem.LoadPlayer() != null)
		{
            TimeData data = SaveSystem.LoadPlayer();

            
            Level = data.level[IndexofScene];
            Debug.Log("The current level is = " + Level);
            TimeofLevel = data.Timer[IndexofScene];
            Debug.Log("The current timer is = " + TimeofLevel);
        }
		else
		{

		}
       
  //      if (IndexofScene == 1)
  //      {
  //          TimeofLevel = data.Timer1;
            

  //      }
  //      if (IndexofScene == 2)
  //      {
  //          TimeofLevel = data.Timer2;

  //      }
  //      if (IndexofScene == 3)
  //      {
  //          TimeofLevel = data.Timer3;

  //      }
  //      if (IndexofScene == 4)
  //      {
  //          TimeofLevel = data.Timer4;

  //      }
  //      if(IndexofScene == 0)
		//{
  //          Debug.Log("WHY THE FUCK IS IT 0");
		//}
    }

    
}
