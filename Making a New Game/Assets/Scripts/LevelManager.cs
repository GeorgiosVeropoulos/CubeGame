using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int CubesToKill;
    public int CurrentCubesKilled = 0;
    public int Index;
    public TimeCounter UIMenu;
    public TimerToStart timertoStart;
   
	private void Awake()
	{
        //data = SaveSystem.LoadPlayer();
        Time.timeScale = 1f;
    }
	// Start is called before the first frame update
	public void Start()
    {
        
        Scene currentscene = SceneManager.GetActiveScene();
        Index = currentscene.buildIndex;
    }

    // Update is called once per frame
    public void Update()
    {
        if(timertoStart.begingame == true)
		{
            if (CubesToKill == CurrentCubesKilled)
            {
                SlowLevelGame();

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (Time.timeScale == 1f)
                {
                    SceneManager.LoadScene(Index);
                    UnPauseGame();
                }
                else
                {

                }

            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (Time.timeScale == 1f)
                {
                    UIMenu.PauseMenu.SetActive(true);
                    PauseGame();
                }
                else if (Time.timeScale == 0f)
                {
                    UIMenu.PauseMenu.SetActive(false);
                    UnPauseGame();
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CurrentCubesKilled = CubesToKill;
            }
        }
        
        
		
    }
    public void SlowLevelGame()
	{
        if(Time.timeScale >= 0.3f)
		{
            Time.timeScale -= 0.01f;

        }
    }
    public void UnPauseGame()
	{
        Time.timeScale = 1;
        UIMenu.PauseMenu.SetActive(false);

    }
    public void PauseGame()
	{
        Time.timeScale = 0;
	}
    public void MainMenu()
	{
        SceneManager.LoadScene(0);
	}
}
