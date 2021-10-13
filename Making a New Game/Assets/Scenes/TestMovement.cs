using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
	private Vector3 offset;

	public GameObject player;
	public GameObject center;
	public GameObject up;
	public GameObject Down;
	public GameObject Left;
	public GameObject Right;

	public int step = 9;
	public float speed = 0.01f;

	bool input = true;

	public void Update()
	{
		if(input == true)
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				StartCoroutine("moveUp");
				input = false;
			}


			if (Input.GetKey(KeyCode.DownArrow))
			{
				StartCoroutine("moveDown");
				input = false;
			}


			if (Input.GetKey(KeyCode.LeftArrow))
			{
				StartCoroutine("moveLeft");
				input = false;
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				StartCoroutine("moveRight");
				input = false;
			}
		}
	}
	IEnumerator moveUp()
	{
		for(int i = 0; i<(90/step); i++)
		{
			player.transform.RotateAround(up.transform.position, Vector3.right, step);
			yield return new WaitForSeconds(speed);

		}
		center.transform.position = player.transform.position;
		input = true;

	}
	IEnumerator moveDown()
	{
		for (int i = 0; i < (90 / step); i++)
		{
			player.transform.RotateAround(Down.transform.position, Vector3.left, step);
			yield return new WaitForSeconds(speed);

		}
		center.transform.position = player.transform.position;
		input = true;

	}
	IEnumerator moveLeft()
	{
		for (int i = 0; i < (90 / step); i++)
		{
			player.transform.RotateAround(Left.transform.position, Vector3.forward, step);
			yield return new WaitForSeconds(speed);

		}
		center.transform.position = player.transform.position;
		input = true;

	}
	IEnumerator moveRight()
	{
		for (int i = 0; i < (90 / step); i++)
		{
			player.transform.RotateAround(Right.transform.position, Vector3.back, step);
			yield return new WaitForSeconds(speed);

		}
		center.transform.position = player.transform.position;
		input = true;
	}
}
