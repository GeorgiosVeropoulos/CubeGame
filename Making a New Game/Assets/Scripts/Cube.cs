using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float tumblingDuration = 0.2f;
    Rigidbody mRigidbody;
    public float Thrust = 20f;
	public bool freecontrols = false;
	
	public Vector3 dir;
	
	private void Awake()
	{
		//SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
		dir = Vector3.zero;
	}


	public void Start()
	{
        mRigidbody = GetComponent<Rigidbody>();
		freecontrols = false;
	}
	
	public void Update()
	{

		// CHECKS IF WE ARE ON THE FLOOR
		RaycastHit hit;
		if(Physics.Raycast(transform.position, -Vector3.up, out hit, 4f))
		{
			Debug.DrawRay(transform.position, -Vector3.up * hit.distance, Color.yellow);
			Debug.Log(hit.transform.gameObject.tag);
			if(hit.transform.gameObject.tag == "Floor")
			{
				
			}
			
		}
		else
		{
			Debug.Log("CALLED");
			mRigidbody.freezeRotation = false;
			freecontrols = true;
			mRigidbody.AddForce(Vector3.down);
		}
		
		
		//Debug.Log(detect.Direction);
		if (freecontrols == false && Time.timeScale == 1)
		{
			mRigidbody.freezeRotation = true;
			dir = Vector3.zero;
			
			#region Normal Controls
			if (Input.GetKey(KeyCode.W))
			{
				dir = Vector3.forward;
			}


			if (Input.GetKey(KeyCode.S))
			{
				dir = Vector3.back;
			}


			if (Input.GetKey(KeyCode.A))
			{
				dir = Vector3.left;
			}

			if (Input.GetKey(KeyCode.D))
			{
				dir = Vector3.right;
			}
			#endregion
			if (dir != Vector3.zero && !isTumbling)
			{
				StartCoroutine(Tumble(dir));
			}
		}
		else
		{
			//dir = Vector3.zero;
		}

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
