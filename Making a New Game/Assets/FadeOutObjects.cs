using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutObjects : MonoBehaviour
{


	
	public Transform player;
	public Transform[] Objects;
	public LayerMask m_LayerMask;
	public float hitdistance;

	public Vector3 StartofRay;
	public Vector3 RayDirection;
	public float Xposition = 0f;
	public float Yposition = 0.3f;
	public float Zposition = -0.2f;


	public void Start()
	{
		
		
	}
	
	public void Update()
	{
		//// Bit shift the index of the layer (8) to get a bit mask
		//int layerMask = 1 << 8;

		//// This would cast rays only against colliders in layer 8.
		//// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
		//layerMask = ~layerMask;
		StartofRay = Camera.main.transform.position;
		RayDirection = (player.position + new Vector3(Xposition, Yposition, Zposition)) - transform.position;
		RaycastHit hit;
		// Does the ray intersect any objects excluding the player layers
		if (Physics.Raycast(StartofRay, RayDirection, out hit, hitdistance, m_LayerMask))
		{
			hit.transform.GetComponent<Dither>().Dithering = true;
			
			Debug.DrawRay(StartofRay, RayDirection, Color.yellow);



			

		}
		else
		{

			for (int i = 0; i < Objects.Length; i++)
			{
				Objects[i].transform.GetComponent<Dither>().Dithering = false;
			}
			Debug.DrawRay(StartofRay, RayDirection, Color.white);
			

		}
	}

	

}