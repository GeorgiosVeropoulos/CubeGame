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


	bool m_Started;
	public LayerMask m_LayerMask;
	void Start()
	{
		//Use this to ensure that the Gizmos are being drawn when in Play Mode.
		m_Started = true;
	}
	void FixedUpdate()
	{
		MyCollisions();
	}

	void MyCollisions()
	{
		//Use the OverlapBox to detect if there are any other colliders within this box area.
		//Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
		Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * 2, Quaternion.identity, m_LayerMask);
		int i = 0;
		//Check when there is a new collider coming into contact with the box
		while (i < hitColliders.Length)
		{
			//Output all of the collider names
			Debug.Log("Hit : " + hitColliders[i].name + i);
			//Increase the number of Colliders in the array
			i++;
		}
	}

	//Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		//Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
		if (m_Started)
			//Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
			Gizmos.DrawWireCube(transform.position, transform.localScale * 2);
	}
}