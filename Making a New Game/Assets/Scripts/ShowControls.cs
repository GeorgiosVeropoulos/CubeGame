using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowControls : MonoBehaviour
{
    public GameObject Settings;
    public GameObject SettingsButton;
    public GameObject BackButton;
    public GameObject RestofUI;
    public GameObject LevelsUI;
   
    private Scene currentscene;
    public bool ShowSettings = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    void Start()
    {
        currentscene = SceneManager.GetActiveScene();
        //Debug.Log(currentscene.buildIndex);
        BackButton.SetActive(false);
    }
    public void QuitGame()
	{
        Application.Quit();
        
	}
    public void EnableControlsMenu()
	{
        if(ShowSettings == false)
		{
            Settings.SetActive(true);
            RestofUI.SetActive(false);
            LevelsUI.SetActive(false);
            ShowSettings = true;
        }
		else
		{
            Settings.SetActive(false);
            RestofUI.SetActive(true);
            LevelsUI.SetActive(false);
            ShowSettings = false;
        }


	}
    
    public void EnableLevels()
	{
        BackButton.SetActive(true);
        SettingsButton.SetActive(false);
        LevelsUI.SetActive(true);
        RestofUI.SetActive(false);
	}
    public void DisableLevels()
	{
        BackButton.SetActive(false);
        SettingsButton.SetActive(true);
        LevelsUI.SetActive(false);
        RestofUI.SetActive(true);
    }
    public void LoadLevel_1()
	{
        SceneManager.LoadScene(1);
	}
    public void LoadLevel_2()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel_3()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel_4()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevel_5()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevel_6()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadLevel_7()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadLevel_8()
    {
        SceneManager.LoadScene(8);
    }
}
