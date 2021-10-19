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
	public Image showing;
	public int numbertoshow;
	public Material SkinShowing;
	
	public Material[] skins;
	public Sprite[] spriteskin;
	public bool BoughtSkin1;
	public bool BoughtSkin2;
	public bool BoughtSkin3;
	public bool BoughtSkin4;
	public bool BoughtSkin5;
	public SkinManager skinmanager;
	// Check cube script to change the skin of the player
	public void Awake()
	{
		
		showing.material = null;
		skinmanager = FindObjectOfType<SkinManager>();
	}
	public void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
    {
		
		if(numbertoshow == 0)
		{
			showing.sprite = spriteskin[0];
			skinmanager.SkingToUse = skins[0];
			nameofskintext.text = "No Skin";

			priceofskintext.text = "";
		}
        if(numbertoshow == 1)
		{
			showing.sprite = spriteskin[1];
			if(BoughtSkin1 == true)
			{
				skinmanager.SkingToUse = skins[1];
			}
			
			//NameofSkin.text = "Inner Cube";
			nameofskintext.text = "Inner Cube";
			
			priceofskintext.text = "5.000.000";
		}
		if(numbertoshow == 2)
		{
			showing.sprite = spriteskin[2];
			if(BoughtSkin2 == true)
			{
				skinmanager.SkingToUse = skins[2];
			}
			
			//NameofSkin.text = "Two lines";
			//PriceofSkin.text = "2.000.000";
			nameofskintext.text = "Two lines";
			//PriceofSkin.text = "5.000.000";
			priceofskintext.text = "2.000.000";
		}
		if (numbertoshow == 3)
		{
			showing.sprite = spriteskin[3];
			skinmanager.SkingToUse = skins[3];
			nameofskintext.text = "Lava";
			priceofskintext.text = "5.000.000";
		}
		if(numbertoshow == 4)
		{
			showing.sprite = spriteskin[4];
			skinmanager.SkingToUse = skins[4];
			nameofskintext.text = "Tiles";
			priceofskintext.text = "6.000.000";
		}
		if(numbertoshow == 5)
		{
			showing.sprite = spriteskin[5];
			skinmanager.SkingToUse = skins[5];
			nameofskintext.text = "Wood";
			priceofskintext.text = "6.000.000";
		}

	}
	public void IncreaseOne()
	{
		if(numbertoshow < 5)
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
			numbertoshow = 5;
		}
		else
		{
			numbertoshow--;
		}
	}
}
