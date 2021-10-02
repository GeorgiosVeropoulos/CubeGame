using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColowSwitcher : MonoBehaviour
{
	[Range(1,4)]
	[Tooltip("1= Red, 2= blue , 3= yellow , 4= green")]
	public int colorpicker;
	private void Awake()
	{
		MeshRenderer meshthis = this.gameObject.GetComponent<MeshRenderer>();
		
		if(colorpicker == 1)
		{
			meshthis.material.color = Color.red;
		}
		if (colorpicker == 2)
		{
			meshthis.material.color = Color.blue;
		}
		if (colorpicker == 3)
		{
			meshthis.material.color = Color.yellow;
		}
		if (colorpicker == 4)
		{
			meshthis.material.color = Color.green;
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			MeshRenderer mesh = other.gameObject.GetComponent<MeshRenderer>();
			
			if (colorpicker == 1)
			{
				mesh.material.color = Color.red;
			}
			if (colorpicker == 2)
			{
				mesh.material.color = Color.blue;
			}
			if (colorpicker == 3)
			{
				mesh.material.color = Color.yellow;
			}
			if (colorpicker == 4)
			{
				mesh.material.color = Color.green;
			}
		}
	}
}
