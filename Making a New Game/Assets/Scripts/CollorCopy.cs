using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorCopy : MonoBehaviour
{
    public GameObject cubetoCopy;
    public bool UseShader = false;

    public void Start()
    {
        MeshRenderer thismesh = this.gameObject.GetComponent<MeshRenderer>();
        if (UseShader == false){
            thismesh.material.color = cubetoCopy.GetComponent<MeshRenderer>().material.color;

        }
        else
		{
            thismesh.material.SetColor("_Color", cubetoCopy.GetComponent<MeshRenderer>().material.color);

        }
    }
}
