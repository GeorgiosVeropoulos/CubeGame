using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowControls : MonoBehaviour
{
    public GameObject Controls;
    public GameObject RestofUI;
    public GameObject LevelsUI;
    private Scene currentscene;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    void Start()
    {
        currentscene = SceneManager.GetActiveScene();
        //Debug.Log(currentscene.buildIndex);
    }
    public void EnableControlsMenu()
	{
        Controls.SetActive(true);
        RestofUI.SetActive(false);


	}
    public void DisableControlsMenu()
	{
        Controls.SetActive(false);
        RestofUI.SetActive(true);
    }
    public void EnableLevels()
	{
        LevelsUI.SetActive(true);
        RestofUI.SetActive(false);
	}
    public void DisableLevels()
	{
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
}
