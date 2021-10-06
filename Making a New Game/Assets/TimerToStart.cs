using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerToStart : MonoBehaviour
{

    public float timeValue = 5;
    public bool begingame = false;
    public TextMeshProUGUI timeToStartText;
    public GameObject TextHolder;

    // Start is called before the first frame update
    void Start()
    {
        TextHolder.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeValue> 0)
		{
            timeValue -= Time.deltaTime;

        }
		else
		{
            timeValue = 0;
            begingame = true;
            TextHolder.SetActive(false);
		}
        DisplayTime(timeValue);
        
    }

    void DisplayTime(float timetoDisplay)
	{

        float seconds = Mathf.FloorToInt(timetoDisplay % 60);
        
        timeToStartText.text = string.Format("{0:0}", seconds);

        if (timetoDisplay < 1)
        {
            //timetoDisplay = 0;
            //timetoDisplay.ToString("GO");
            timeToStartText.text = "GO";
        }
    }

}
