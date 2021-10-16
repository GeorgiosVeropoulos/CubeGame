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
		//for(int i =0; i < listToActivate.Length; i++)
		//{
		//	listToActivate[i].SetActive(false);
		//}
		//for (int j = 0; j < lisToRemove.Length; j++)
		//{
		//	listToActivate[j].SetActive(true);
		//}
	}
	// Start is called before the first frame update
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
