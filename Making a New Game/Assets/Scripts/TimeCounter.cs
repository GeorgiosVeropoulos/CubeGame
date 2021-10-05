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
    public GameManager Gamemanager;
   

    // private TextMesh theTextmesh;
    public void Awake()
	{
        //Save();

        Gamemanager = FindObjectOfType<GameManager>();
        IndexofScene = SceneManager.GetActiveScene().buildIndex;
        Level = IndexofScene;
        TimeofFinish = Gamemanager.times[Level];
    }

	void Start()
    {
        Debug.Log("Index of scene is " + IndexofScene);
        //TimeofFinish = PlayerPrefs.GetFloat("highscore", TimeofFinish);
        
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

            // Create a save if the timer was better than the previous one
            
            if(TimeofLevel <= TimeofFinish)
			{

                Gamemanager.times[Level] = TimeofLevel;
               
            }
			else
			{
                if (TimeofFinish == 0)
                {
                    Gamemanager.times[Level] = TimeofLevel;
                }
            }
            
            
            
            //SavingandLoading();
        }
        if(Time.timeScale == 1)
		{
            timer += Time.deltaTime;

            
            txtmeshtext.GetComponent<TextMeshProUGUI>().text = "" + timer.ToString();
        }

		

        
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
    


}
