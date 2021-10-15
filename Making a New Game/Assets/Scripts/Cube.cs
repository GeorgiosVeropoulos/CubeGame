using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour
{
    public float tumblingDuration = 0.2f;
    Rigidbody mRigidbody;
    public float Thrust = 20f;
	public bool freecontrols = false;
	public TimerToStart timetostart;
	public Vector3 dir;
	public bool Up = false;
	public bool down = false;
	public bool left = false;
	public bool right = false;
	

	private void Awake()
	{
		//SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
		dir = Vector3.zero;
		this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
	}


	public void Start()
	{
        mRigidbody = GetComponent<Rigidbody>();
		freecontrols = false;
		ONFINGERUP();
	}
	public void Update()
	{
		// CHECKS IF WE ARE ON THE FLOOR
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, 4f))
		{
			Debug.DrawRay(transform.position, -Vector3.up * hit.distance, Color.yellow);
			//Debug.Log(hit.transform.gameObject.tag);
			if (hit.transform.gameObject.tag == "Floor")
			{
				//Debug.Log("HIT");
			}

		}
		else
		{
			Debug.Log("DIDNT HIT");
			Drop();
		}
		if (freecontrols == false && Time.timeScale == 1 && timetostart.begingame == true)
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

			if (Input.GetKey(KeyCode.D) || right == true)
			{
				dir = Vector3.right;
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
		//Debug.Log("CALLED");
		mRigidbody.freezeRotation = false;
		freecontrols = true;
		mRigidbody.AddForce(Vector3.down);
	}
	public void LateUpdate()
	{



		//Debug.Log(detect.Direction);

		


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
