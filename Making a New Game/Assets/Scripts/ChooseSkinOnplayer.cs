using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ChooseSkinOnplayer : MonoBehaviour
{
	
	public TextMeshProUGUI nameofskintext;
	public TextMeshProUGUI priceofskintext;
	public GameObject BuyButton;
	public Image showing;
	public int numbertoshow;
	public Material SkinShowing;
	public TotalPoints points;
	public Material[] skins;
	public Sprite[] spriteskin;
	public int[] priceofskin;
	public SkinManager skinmanager;
	public ScoreManager scoremanager;
	
	// Check cube script to change the skin of the player
	public void Awake()
	{
		
		//showing.material = null;
		skinmanager = FindObjectOfType<SkinManager>();
		scoremanager = FindObjectOfType<ScoreManager>();
	}
	public void Start()
	{
		numbertoshow = skinmanager.numbertoHold;
	}

	// Update is called once per frame
	void Update()
    {
		if (skinmanager.skins[numbertoshow] == false)
		{

			BuyButton.SetActive(true);
		}
		else if(skinmanager.skins[numbertoshow] == true)
		{
			
			BuyButton.SetActive(false);
			
		}
		if (numbertoshow == 0)
		{
			showing.sprite = spriteskin[0];
			BuyButton.SetActive(false);
			skinmanager.SkingToUse = skins[0];
			nameofskintext.text = "No Skin";
			skinmanager.numbertoHold = 0;
			priceofskintext.text = "";
		}
        if(numbertoshow == 1)
		{
			showing.sprite = spriteskin[1];
			if(skins[1] == true)
			{
				skinmanager.SkingToUse = skins[1];
				priceofskintext.text = "";
			}
			
			priceofskintext.text = "Price = " + priceofskin[1].ToString();
			skinmanager.numbertoHold = 1;
			nameofskintext.text = "Inner Cube";
			
			
		}
		if(numbertoshow == 2)
		{
			showing.sprite = spriteskin[2];
			if(skins[2] == true)
			{
				skinmanager.SkingToUse = skins[2];
			}
			
			skinmanager.numbertoHold = 2;
			nameofskintext.text = "Two lines";
			priceofskintext.text = "Price = " + priceofskin[2].ToString();
		}
		if (numbertoshow == 3)
		{
			showing.sprite = spriteskin[3];
			if (skins[3] == true)
			{
				skinmanager.SkingToUse = skins[3];
			}
			skinmanager.numbertoHold = 3;
			nameofskintext.text = "The Missing Data";
			priceofskintext.text = "Price = " + priceofskin[3].ToString();
		}
		if(numbertoshow == 4)
		{
			showing.sprite = spriteskin[4];
			if (skins[4] == true)
			{
				skinmanager.SkingToUse = skins[4];
			}
			skinmanager.numbertoHold = 4;
			nameofskintext.text = "Hole";
			priceofskintext.text = "Price = " + priceofskin[4].ToString();
		}
		if(numbertoshow == 5)
		{
			showing.sprite = spriteskin[5];
			if (skins[5] == true)
			{
				skinmanager.SkingToUse = skins[5];
			}
			skinmanager.numbertoHold = 5;
			nameofskintext.text = "IronBox";
			priceofskintext.text = "Price = " + priceofskin[5].ToString();
		}
		if (numbertoshow == 6)
		{
			showing.sprite = spriteskin[6];
			if (skins[6] == true)
			{
				skinmanager.SkingToUse = skins[6];
			}
			skinmanager.numbertoHold = 5;
			nameofskintext.text = "Halloween";
			priceofskintext.text = "Price = " + priceofskin[6].ToString();
		}

	}
	public void IncreaseOne()
	{
		if(numbertoshow < 6)
		{
			numbertoshow++;
		}
		else
		{
			numbertoshow = 0;
		}
		
	}
	public void DecreaseNumber()
	{
		if (numbertoshow == 0)
		{
			numbertoshow = 6;
		}
		else
		{
			numbertoshow--;
		}
	}
	public void Buy()
	{
		if(skinmanager.skins[numbertoshow] == false)
		{
			
			if (points.totalpoints >= priceofskin[numbertoshow])
			{
				points.totalpoints -= priceofskin[numbertoshow];
				skinmanager.skins[numbertoshow] = true;
				
				Debug.Log(points.totalpoints);
				scoremanager.scores[0] = points.totalpoints;
				scoremanager.SaveData();
				skinmanager.SaveData();
			}
		}
		else
		{
			
			Debug.Log("ALREADY BOUGHT");
		}
		

	}
}
