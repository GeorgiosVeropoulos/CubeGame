using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KILLALL : MonoBehaviour
{
	public int Index;
	public void Start()
	{
		Scene currentscene = SceneManager.GetActiveScene();
		Index = currentscene.buildIndex;

	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<BoxCollider>() != null)
		{
			if (other.gameObject.tag == "Player")
			{
				SceneManager.LoadScene(Index);
			}
			else
			{
				Destroy(other.gameObject);
			}
			

		}
		
	}
}
