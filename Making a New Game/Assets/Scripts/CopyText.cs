using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CopyText : MonoBehaviour
{
    public GameObject First;

	private void Start()
	{
		this.gameObject.GetComponent<Text>().text = First.GetComponent<Text>().text;
	}
	private void Update()
	{
		
		TimeStealer();
	}
	private void TimeStealer() 
	{
		this.gameObject.GetComponent<Text>().text = First.GetComponent<Text>().text;
	}
}
