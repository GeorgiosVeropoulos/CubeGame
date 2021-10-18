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
	public Texture SkinShowing;
	public Texture Skin1;
	public Texture Skin2;
	public Sprite skin1;
	public Sprite skin2;
	public SkinManager skinmanager;
	// Check cube script to change the skin of the player
	public void Awake()
	{
		
		showing.sprite = null;
		skinmanager = FindObjectOfType<SkinManager>();
	}
	public void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
    {
	
		
        if(numbertoshow == 1)
		{
			showing.sprite = skin1;
			
			skinmanager.SkingToUse = Skin1;
			//NameofSkin.text = "Inner Cube";
			nameofskintext.text = "Inner Cube";
			//PriceofSkin.text = "5.000.000";
			priceofskintext.text = "5.000.000";
		}
		if(numbertoshow == 2)
		{
			showing.sprite = skin2;
			skinmanager.SkingToUse = Skin2;
			//NameofSkin.text = "Two lines";
			//PriceofSkin.text = "2.000.000";
			nameofskintext.text = "Two lines";
			//PriceofSkin.text = "5.000.000";
			priceofskintext.text = "2.000.000";
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
