using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutObjects : MonoBehaviour
{

	#region raycast single item hide
	//  private Vector3 middlepos;
	//  public GameObject player;
	//  public Material transparent;
	//  public Material Opaque;
	//  public GameObject stored;
	//  public Color storedcolor;
	//  private MeshRenderer meshrend;
	//  public bool hittedcube;
	//  public bool colorsaver;
	//  // Start is called before the first frame update
	//  void Start()
	//  {
	//      middlepos = new Vector3(Screen.width / 2, Screen.height / 2);
	//  }

	//  // Update is called once per frame
	//  void Update()
	//  {


	//var ray = Camera.main.ScreenPointToRay(middlepos);
	//      RaycastHit hit;
	//      if(Physics.Raycast(ray, out hit))
	//{

	//          //Debug.Log("HITTED " + hitted.name);
	//          if (hit.collider.tag == "Transparent")
	//	{
	//              Debug.Log("HITTED CUBE");
	//              GameObject hitted = hit.transform.gameObject;
	//              stored = hitted;

	//		meshrend = hitted.GetComponent<MeshRenderer>();
	//              if(colorsaver == false)
	//		{
	//                  storedcolor = meshrend.material.color;
	//                  colorsaver = true;
	//              }


	//              hittedcube = true;


	//              meshrend.material = transparent;


	//	}

	//          if (hit.collider.tag == "Player")
	//	{
	//              hittedcube = false;
	//              colorsaver = false;
	//              stored.GetComponent<MeshRenderer>().material = Opaque;
	//              stored.GetComponent<MeshRenderer>().material.color = storedcolor;
	//          }
	//	else
	//	{

	//	}

	//}
	//else
	//{
	//          if(hittedcube == false)
	//	{
	//              Debug.Log("CHANGED BACK");
	//              stored.GetComponent<MeshRenderer>().material = Opaque;
	//          }

	//}


	//  }
	#endregion


	public Transform player;
	public Transform[] Objects;
	public LayerMask m_LayerMask;
	public int hitdistance;
	
	void FixedUpdate()
	{
		//// Bit shift the index of the layer (8) to get a bit mask
		//int layerMask = 1 << 8;

		//// This would cast rays only against colliders in layer 8.
		//// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
		//layerMask = ~layerMask;

		RaycastHit hit;
		// Does the ray intersect any objects excluding the player layer
		if (Physics.Raycast(transform.position, player.position - transform.position, out hit, hitdistance, m_LayerMask))
		{
			Debug.DrawRay(Camera.main.transform.position, (player.position - transform.position) * 1f, Color.yellow);
			Debug.Log("Did Hit");
			
			hit.transform.GetComponent<Dither>().Dithering = true;
			
		}
		else
		{
			//foreach(Transform obj in Objects)
			//{
				
			//	obj.transform.GetComponent<Dither>().Dithering = false;
			//}
			for(int i = 0; i<Objects.Length; i++)
			{
				Objects[i].transform.GetComponent<Dither>().Dithering = false;
			}
			Debug.DrawRay(Camera.main.transform.position, (player.position - transform.position) * 1, Color.white);
			Debug.Log("Did not Hit");
		}
	}
}