using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CubeTesting : MonoBehaviour
{
	public float tumblingDuration = 0.2f;
	Rigidbody mRigidbody;
	public float Thrust = 20f;
	public bool freecontrols = false;
	public Vector3 currentpos;
	public Vector3 dir;
	public bool Up = false;
	public bool down = false;
	public bool left = false;
	public bool right = false;
	public Vector3 endPosition;
	public Vector3 startPosition;
	public bool isDropping = false;
	public bool goingright = false;
	//public Material testing;

	private void Awake()
	{
		//SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
		dir = Vector3.zero;
		//this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
		
	}


	public void Start()
	{
		// THIS CHANGES THE SKIN OF PLAYER
		//this.gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", skinmanager.SkingToUse);
		
		this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
		mRigidbody = GetComponent<Rigidbody>();
		freecontrols = false;
		ONFINGERUP();
	}
	public void FixedUpdate()
	{
		currentpos = this.gameObject.transform.position;
		// CHECKS IF WE ARE ON THE FLOOR
		RaycastHit hit;
		RaycastHit hittwo;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, 4f))
		{
			
			Debug.DrawRay(transform.position, -Vector3.up * hit.distance, Color.yellow);
			//Debug.Log(hit.transform.gameObject.tag);
			if (hit.transform.gameObject.tag == "Floor")
			{

				if (hit.distance <= 0.5)
				{
					Debug.Log("HIT FLOOR");
					mRigidbody.freezeRotation = true;
					isDropping = false;
					freecontrols = false;
				}
				if (hit.distance > 0.6)
				{
					Debug.Log("Drop Started");
					mRigidbody.freezeRotation = true;
					isDropping = true;
					freecontrols = true;
				}
				else if(hit.distance > 4)
				{
					Debug.Log("DIDNT HIT");
					Drop();
				}
			}
			
			
		}

		if (Physics.Raycast(transform.position, -Vector3.left, out hittwo, 4f))
		{
			Debug.DrawRay(transform.position, -Vector3.left * hittwo.distance, Color.blue);
			//Debug.Log(hit.transform.gameObject.tag);
			if (hittwo.transform.gameObject.tag == "Floor")
			{
				if (hittwo.distance <= 0.5 && isDropping == false)
				{
					Debug.Log("HIT FLOOR ON SIDE");

					//freecontrols = false;
					goingright = true;
					//if (Input.GetKey(KeyCode.D) || right == true)
					//{
					//	freecontrols = true;
					//	Vector3 positiontohold = new Vector3(currentpos.x, currentpos.y, currentpos.z);
					//	Debug.Log(positiontohold);
					//	Debug.Log("Moving On Top");
					//	this.gameObject.transform.position = new Vector3(positiontohold.x + 1, positiontohold.y + 1f, positiontohold.z);
					//	goingright = true;
					//	this.gameObject.transform.position = new Vector3(positiontohold.x - 1f, positiontohold.y + 1f, positiontohold.z);

					//}
				}
				else
				{
					goingright = false;
				}

			}


		}

		if (freecontrols == false && Time.timeScale == 1)
		{
			mRigidbody.freezeRotation = true;
			dir = Vector3.zero;

			#region Normal Controls
			if (Input.GetKey(KeyCode.W) || Up == true)
			{
				dir = Vector3.forward;
			}


			if (Input.GetKey(KeyCode.S) || down == true)
			{
				dir = Vector3.back;
			}


			if (Input.GetKey(KeyCode.A) || left == true)
			{
				dir = Vector3.left;
			}
			//if (Input.GetKey(KeyCode.D) || right == true)
			//{
			//	dir = Vector3.right;
			//	Debug.Log("PRESSED");


			//}
			if(goingright == true)
			{
				if (Input.GetKey(KeyCode.D) || right == true)
				{
					dir = Vector3.right;
					startPosition = transform.position;
					transform.position = new Vector3(startPosition.x, startPosition.y + 1, startPosition.z);
					goingright = false;
				}
			}
			else if (goingright == false)
			{
				if (Input.GetKey(KeyCode.D) || right == true)
				{
					dir = Vector3.right;
				}
			}

			#endregion
			if (dir != Vector3.zero && !isTumbling)
			{
				StartCoroutine(Tumble(dir));
			}
			else
			{
				//Up = false;
				//down = false;
				//left = false;
				//right = false;
			}

		}
		else
		{
			//dir = Vector3.zero;
		}
		//GOUP();
		//GODOWN();
		//GOLEFT();
		//GORIGHT();
		
		
		
	}
	public void Drop()
	{
		Debug.Log("CALLED");
		mRigidbody.freezeRotation = false;
		freecontrols = true;
		mRigidbody.AddForce(Vector3.down);
	}
	public void OnCollisionEnter(Collision collision)
	{
		
	}
	
	public void GOUP()
	{
		Debug.Log("HAND DOWN");
		Up = true;
		down = false;
		left = false;
		right = false;

	}
	public void GODOWN()
	{
		Up = false;
		down = true;
		left = false;
		right = false;
	}
	public void GOLEFT()
	{
		Up = false;
		down = false;
		left = true;
		right = false;
	}
	public void GORIGHT()
	{
		Up = false;
		down = false;
		left = false;
		right = true;
	}
	public void ONFINGERUP()
	{
		Up = false;
		down = false;
		left = false;
		right = false;
		//Debug.Log("HAND UP");
	}
	public void onfingerdown()
	{

	}
	bool isTumbling = false;
	IEnumerator Tumble(Vector3 direction)
	{
		isTumbling = true;

		var rotAxis = Vector3.Cross(Vector3.up, direction);
		var pivot = (transform.position + Vector3.down * 0.5f) + direction * 0.5f;

		var startRotation = transform.rotation;
		var endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;

		var startPosition = transform.position;
		var endPosition = transform.position + direction;
		
		
		var rotSpeed = 90.0f / tumblingDuration;
		var t = 0.0f;

		while (t < tumblingDuration)
		{
			t += Time.deltaTime;
			if (t < tumblingDuration)
			{
				transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
				yield return null;

			}
			else
			{
				transform.rotation = endRotation;
				transform.position = endPosition;
			}
		}

		isTumbling = false;
	}
	
}
