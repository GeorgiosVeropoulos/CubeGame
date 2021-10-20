using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideButtonsScript : MonoBehaviour
{

    public GameObject PauseTime;
    public GameObject PlayTime;

    // Start is called before the first frame update
    void Start()
    {
        PauseTime.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1f)
		{
            PauseTime.SetActive(true);
            PlayTime.SetActive(false);
        }
        else if(Time.timeScale == 0f)
		{
            PauseTime.SetActive(false);
            PlayTime.SetActive(true);
        }
    }

    public void Pause()
	{
        Time.timeScale = 0;
        PauseTime.SetActive(false);
        PlayTime.SetActive(true);
	}
    public void Play()
	{
        Time.timeScale = 1f;
        PauseTime.SetActive(true);
        PlayTime.SetActive(false);
    }
}
