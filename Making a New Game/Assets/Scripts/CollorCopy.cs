using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorCopy : MonoBehaviour
{
    public GameObject cubetoCopy;
    public bool UseShader = false;
    public bool updatecolor = false;
    private MeshRenderer thismesh;
    public void Start()
    {
        thismesh = this.gameObject.GetComponent<MeshRenderer>();
        if (UseShader == false){
            thismesh.material.color = cubetoCopy.GetComponent<MeshRenderer>().material.color;

        }
        else
		{
            thismesh.material.SetColor("_Color", cubetoCopy.GetComponent<MeshRenderer>().material.color);

        }
    }
	public void Update()
	{
		if(updatecolor == true)
		{
            thismesh.material.color = cubetoCopy.GetComponent<MeshRenderer>().material.color;
        }
		else
		{

		}
	}
}
