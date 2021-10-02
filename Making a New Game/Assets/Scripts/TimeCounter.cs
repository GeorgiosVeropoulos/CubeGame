using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public float timer;
    public float TimeofLevel;
    public GameObject txtmeshtext;
    
    public GameObject TimeTopLeft;
    public GameObject Timer;
    public GameObject PauseMenu;
    public GameObject EndScreenTimer;
    public GameObject manager;
    private int IndexofScene;
    // private TextMesh theTextmesh;
    void Start()
    {
        IndexofScene = SceneManager.GetActiveScene().buildIndex;
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
            
            Debug.Log("your time was " + TimeofLevel);
        }
        if(Time.timeScale == 1)
		{
            timer += Time.deltaTime;

            
            txtmeshtext.GetComponent<TextMeshProUGUI>().text = "" + timer.ToString();
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
}
