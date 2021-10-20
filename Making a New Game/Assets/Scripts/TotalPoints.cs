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
	public SkinManager skinmanager;
	public int totalpoints;
	public int currentscore;
	public int buyitem = 100;
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
		//for(int i = 1; i<scores; i++)
		//{
		//	totalpoints += scoremanager.scores[i];
		//}
		//text.text = totalpoints.ToString();
		totalpoints = scoremanager.scores[0];
	}
	public void Update()
	{
		totalpoints = scoremanager.scores[0];

		text.text = totalpoints.ToString();
		
	}
	//public void Buy()
	//{
		
	//	if(totalpoints >= buyitem)
	//	{
	//		totalpoints -= buyitem;
	//		Debug.Log(totalpoints);
	//		scoremanager.scores[0] = totalpoints;
	//		scoremanager.SaveData();
	//	}
		
	//}
}
