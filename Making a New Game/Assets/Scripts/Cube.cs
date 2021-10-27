using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Cube : MonoBehaviour
{
    public float tumblingDuration = 0.17f;           // the duration each tumble takes
    Rigidbody mRigidbody;									
    public float Thrust = 1f;						// the power of the turn
	public bool freecontrols = true;				// locking the controls of player for pause and dropping uses
	public TimerToStart timetostart;
	public Vector3 currentpos;						//
	public Vector3 endPosition;					   //	checks the positions to establish proper movement in walls
	public Vector3 startPosition;				  //
	public Vector3 dir;
	
	private bool Up = false;
	private bool down = false;
	private bool left = false;                      // check the button that is being pressed in the touch controls
	private bool right = false;
	private SkinManager skinmanager;
	
	[SerializeField]
	private bool isDropping = false;
	[SerializeField]
	private bool goingright = false;
	[SerializeField]
	private bool goingleft = false;				// for wall movement
	[SerializeField]
	private bool goingforward = false;
	[SerializeField]
	private bool goingdown = false;
	
	
	private void Awake()
	{
		//SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
		dir = Vector3.zero;
		//this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
		skinmanager = FindObjectOfType<SkinManager>();
	}


	public void Start()
	{
		// THIS CHANGES THE SKIN OF PLAYER
		//this.gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", skinmanager.SkingToUse);
		//this.gameObject.GetComponent<MeshRenderer>().material = skinmanager.SkingToUse;
		this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
		mRigidbody = GetComponent<Rigidbody>();
		freecontrols = true;
		
		ONFINGERUP();
	}
	
	public void Update()
	{
		goingright = false;
		goingleft = false;
		goingforward = false;
		goingdown = false;

		currentpos = this.gameObject.transform.position;
		// CHECKS IF WE ARE ON THE FLOOR
		RaycastHit hit, hitright, hitleft, hitforward, hitback;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, 10f))
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

					if (timetostart.begingame == true)
					{
						freecontrols = false;
					}
					else
					{
						freecontrols = true;
					}
				}
				if (hit.distance > 0.7)
				{
					Debug.Log("Drop Started");
					mRigidbody.freezeRotation = true;
					isDropping = true;
					freecontrols = true;
				}

			}
			if (hit.transform.gameObject.tag == "MiniCube")
			{
				freecontrols = true;
			}
			if(hit.transform.gameObject.tag == "Collector")
			{
				Debug.Log("collector hit");
				freecontrols = true;
				goingdown = false;
				goingforward = false;
				goingright = false;
				goingleft = false;
				isDropping = true;
				Drop();
			}




		}
		else
		{
			Debug.Log("VOID");
			freecontrols = true;
			goingdown = false;
			goingforward = false;
			goingright = false;
			goingleft = false;
			isDropping = true;
			Drop();
		}
		// this checks right walls
		if (Physics.Raycast(transform.position, -Vector3.left, out hitright, 1f))
		{
			Debug.DrawRay(transform.position, -Vector3.left * hitright.distance, Color.blue);
			//Debug.Log(hit.transform.gameObject.tag);
			if (hitright.transform.gameObject.tag == "Floor")
			{
				if (hitright.distance <= 0.6 && isDropping == false && freecontrols == false)
				{
					Debug.Log("HIT FLOOR ON SIDE");

					goingright = true;

				}
				else
				{
					goingright = false;
				}

			}


		}
		// this checks left walls
		if (Physics.Raycast(transform.position, -Vector3.right, out hitleft, 1f))
		{
			Debug.DrawRay(transform.position, -Vector3.right * hitleft.distance, Color.red);
			//Debug.Log(hit.transform.gameObject.tag);
			if (hitleft.transform.gameObject.tag == "Floor")
			{
				if (hitleft.distance <= 0.6 && isDropping == false && freecontrols == false)
				{
					Debug.Log("HIT FLOOR ON SIDE");
					
					goingleft = true;

				}
				else
				{
					goingleft = false;
				}

			}


		}
		// this checks forward walls
		if (Physics.Raycast(transform.position, -Vector3.back, out hitforward, 1f))
		{
			Debug.DrawRay(transform.position, -Vector3.back * hitforward.distance, Color.green);
			//Debug.Log(hit.transform.gameObject.tag);
			if (hitforward.transform.gameObject.tag == "Floor")
			{
				if (hitforward.distance <= 0.6 && isDropping == false && freecontrols == false)
				{
					Debug.Log("HIT FLOOR ON SIDE");

					goingforward = true;

				}
				else
				{
					goingforward = false;
				}

			}


		}
		// this checks back walls
		if (Physics.Raycast(transform.position, -Vector3.forward, out hitback, 1f))
		{
			Debug.DrawRay(transform.position, -Vector3.forward * hitback.distance, Color.green);
			//Debug.Log(hit.transform.gameObject.tag);
			if (hitback.transform.gameObject.tag == "Floor")
			{
				if (hitback.distance <= 0.6 && isDropping == false && freecontrols == false)
				{
					Debug.Log("HIT FLOOR ON SIDE");

					
					goingdown = true;

				}
				else
				{
					goingdown = false;
				}

			}


		}


		// here we do all the movement if the time = 1 so you cant move in pause screen
		// and able to use controls
		if (freecontrols == false && Time.timeScale == 1)
		{
			mRigidbody.freezeRotation = true;
			dir = Vector3.zero;

			#region Normal Controls

			// W KEY
			if (goingforward == true)
			{
				if (Input.GetKey(KeyCode.W) || Up == true)
				{
					dir = Vector3.forward;
					startPosition = transform.position;
					transform.position = new Vector3(startPosition.x, startPosition.y + 1, startPosition.z);
					goingforward = false;
				}
			}
			else if (goingforward == false)
			{
				if (Input.GetKey(KeyCode.W) || Up == true)
				{
					dir = Vector3.forward;
				}
			}
			// S KEY
			if (goingdown == true)
			{
				if (Input.GetKey(KeyCode.S) || down == true)
				{
					dir = Vector3.back;
					startPosition = transform.position;
					transform.position = new Vector3(startPosition.x, startPosition.y + 1, startPosition.z);
					goingdown = false;
				}
			}
			else if (goingdown == false)
			{
				if (Input.GetKey(KeyCode.S) || down == true)
				{
					dir = Vector3.back;
				}
			}

			// A KEY
			if (goingleft == true)
			{
				if (Input.GetKey(KeyCode.A) || left == true)
				{
					dir = Vector3.left;
					startPosition = transform.position;
					transform.position = new Vector3(startPosition.x, startPosition.y + 1, startPosition.z);
					goingleft = false;
				}
			}
			else if (goingleft == false)
			{
				if (Input.GetKey(KeyCode.A) || left == true)
				{
					dir = Vector3.left;
				}
			}

			// D KEY
			if (goingright == true)
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
		else if(freecontrols == true || Time.timeScale != 1)
		{
			//dir = Vector3.zero;
		}
		



	}
	public void Drop()
	{
		//Debug.Log("CALLED");
		mRigidbody.freezeRotation = false;
		freecontrols = true;
		mRigidbody.AddForce(Vector3.down);
	}
	
	public void GOUP()
	{
		
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
