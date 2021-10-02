using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNextPart : MonoBehaviour
{
	public GameObject[] listToActivate;
	public GameObject[] lisToRemove;
	public void Awake()
	{
		foreach(GameObject off in listToActivate)
		{
			off.SetActive(false);
		}
		foreach(GameObject off in lisToRemove)
		{
			off.SetActive(true);
		}
		
	}
	// Start is called before the first frame update
	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			
			
			foreach(GameObject go in listToActivate)
			{
				go.SetActive(true);
			}
			foreach (GameObject go in lisToRemove)
			{
				go.SetActive(false);
			}
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
