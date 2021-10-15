using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TotalPoints : MonoBehaviour
{

    public TextMeshProUGUI text;
	public int scores;
    public ScoreManager scoremanager;
	public int totalpoints;
	// Start is called before the first frame update
	public void Awake()
	{
		scoremanager = FindObjectOfType<GameManager>().GetComponent<ScoreManager>();
		scores = scoremanager.scores.Length;
	}
	private void Start()
	{
		TotalScore();
	}
	public void TotalScore()
	{
		for(int i = 0; i<scores; i++)
		{
			totalpoints += scoremanager.scores[i];
		}
		text.text = totalpoints.ToString();
	}
}
