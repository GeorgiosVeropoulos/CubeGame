using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
	public TextMeshProUGUI text;
	public int _level;
	public float bestscore;
	public ScoreManager scoremanager;
	
	public void Awake()
	{
		scoremanager = FindObjectOfType<GameManager>().GetComponent<ScoreManager>();
	
	}
	public void Start()
	{

		bestscore = scoremanager.scores[_level];
		text.text = scoremanager.scores[_level].ToString();


	}
}
