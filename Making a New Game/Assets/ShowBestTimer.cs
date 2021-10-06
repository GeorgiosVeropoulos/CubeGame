using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowBestTimer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int _level;
    public float bestimer;
    public GameManager Gamemanager;

	public void Awake()
	{
		Gamemanager = FindObjectOfType<GameManager>();
	}
	void Start()
    {
        
		bestimer = Gamemanager.times[_level];
		text.text = Gamemanager.times[_level].ToString();
	}

    
}
