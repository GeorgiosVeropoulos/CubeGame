using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayerScript : MonoBehaviour
{
	public float tumblingDuration = 0.2f;
	Rigidbody mRigidbody;
	public float Thrust = 20f;
	public Vector3 dir = Vector3.zero;
	public Transform[] ListofCheckPoints;
	private void Awake()
	{
		//SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
		dir = Vector3.zero;
	}
	public void Start()
	{
		mRigidbody = GetComponent<Rigidbody>();
		
	}
	private void Update()
	{
		Debug.Log(ListofCheckPoints[1].transform.position);
		Debug.Log(dir);
		//if(gameObject.transform.position != ListofCheckPoints[0].transform.position)
		//{
		//	Debug.Log("it reached here");
		//	dir = Vector3.left;

		//}
		
		if (dir != Vector3.zero && !isTumbling)
		{
			StartCoroutine(Tumble(dir));
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
