using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRotationOfPlayer : MonoBehaviour
{
    public MainMenuPlayerScript player;
    public Vector3 directionToGO;
   
  

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
           
            player.dir = directionToGO;
		}
	}
}
