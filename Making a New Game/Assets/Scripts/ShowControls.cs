using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowControls : MonoBehaviour
{
    
    public GameObject BackButton;
    public GameObject RestofUI;
    public GameObject LevelsUI;
    public GameObject ScoresUI;
    
    public GameObject SkinsUI;
    public GameObject ShopButton;
    public GameObject BackButtonShop;
    
    public GameObject SkinsPlaceHolder;
    public audiocontroller controller;
    private Scene currentscene;
    public TotalPoints points;
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
            
            RestofUI.SetActive(false);
            LevelsUI.SetActive(false);
            ShowSettings = true;
            controller.TrackAudio();
        }
		else
		{
            
            RestofUI.SetActive(true);
            LevelsUI.SetActive(false);
            ShowSettings = false;
        }


	}
    
    public void EnableLevels()
	{
        BackButton.SetActive(true);
       
        LevelsUI.SetActive(true);
        RestofUI.SetActive(false);
        SkinsPlaceHolder.SetActive(false);

	}
    public void DisableLevels()
	{
        BackButton.SetActive(false);
       
        LevelsUI.SetActive(false);
        RestofUI.SetActive(true);
        SkinsPlaceHolder.SetActive(true);
        ScoresUI.SetActive(false);
    }
    public void EnableScore()
	{
        BackButton.SetActive(true);
        
        LevelsUI.SetActive(false);
        RestofUI.SetActive(false);
        ScoresUI.SetActive(true);
        
        //points.TotalScore();
    }
    public void DisableScore()
	{

        BackButton.SetActive(true);
        
        LevelsUI.SetActive(true);
        RestofUI.SetActive(false);
        ScoresUI.SetActive(false);
        
    }
    public void ShowShop()
	{
        
        RestofUI.SetActive(false);
        ShopButton.SetActive(false);
        BackButtonShop.SetActive(true);
        SkinsUI.SetActive(true);
        LevelsUI.SetActive(false);
        
	}
    public void BackButtonofShop()
	{
       
        RestofUI.SetActive(true);
        ShopButton.SetActive(true);
        BackButtonShop.SetActive(false);
        SkinsUI.SetActive(false);
      
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
    public void LoadLevel_9()
    {
        SceneManager.LoadScene(9);
    }
    public void LoadLevel_10()
    {
        SceneManager.LoadScene(10);
    }
    public void LoadLevel_11()
	{
        SceneManager.LoadScene(11);
	}
    public void LoadLevel_12()
    {
        SceneManager.LoadScene(12);
    }
    public void LoadLevel_13()
    {
        SceneManager.LoadScene(13);
    }
    public void LoadLevel_14()
    {
        SceneManager.LoadScene(14);
    }
    public void LoadLevel_15()
    {
        SceneManager.LoadScene(15);
    }
    public void LoadLevel_16()
    {
        SceneManager.LoadScene(16);
    }
    public void LoadLevel_17()
    {
        SceneManager.LoadScene(17);
    }
}
