using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IndicateColor : MonoBehaviour
{
    public Image img;
    public GameObject target;

	public void Start()
	{
		img.color = target.GetComponent<MeshRenderer>().material.color;
	}
	void Update()
    {
        

		float minX = img.GetPixelAdjustedRect().width / 2;
		float maxX = Screen.width - minX;

		float minY = img.GetPixelAdjustedRect().height / 2;
		float maxY = Screen.height - minY;

		Vector2 pos = Camera.main.WorldToScreenPoint(target.transform.position);

		if(Vector3.Dot((target.transform.position - transform.position), transform.forward) < 0)
		{
			//Target behind the player
			if (pos.x < Screen.width / 2)
			{
				pos.x = maxX;
			}
			else
			{
				pos.x = minX;
			}
		}
		pos.x = Mathf.Clamp(pos.x, minX, maxX);
		pos.y = Mathf.Clamp(pos.y, minY, maxY);

		img.transform.position = pos;
	}
}
