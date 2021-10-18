using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNextPart : MonoBehaviour
{
	public GameObject[] listToActivate;
	public GameObject[] lisToRemove;
	public void Awake()
	{
		foreach (GameObject off in listToActivate)
		{
			off.SetActive(false);
		}
		foreach (GameObject off in lisToRemove)
		{
			off.SetActive(true);
		}
		
	}
	
	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Player")
		{


			foreach (GameObject off in listToActivate)
			{
				off.SetActive(true);
			}
			foreach (GameObject off in lisToRemove)
			{
				off.SetActive(false);
			}
			Destroy(this.gameObject);
		}
	}

	
}
