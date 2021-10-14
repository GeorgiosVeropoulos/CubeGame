using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IndicateColor : MonoBehaviour
{
    public Image img;
    public GameObject target;

	public void Start()
	{
		img.color = target.GetComponent<MeshRenderer>().material.color;
	}
	void Update()
    {
        img.transform.position = Camera.main.WorldToScreenPoint(target.transform.position);
    }
}
