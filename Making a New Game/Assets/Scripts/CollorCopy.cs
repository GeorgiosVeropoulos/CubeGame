﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorCopy : MonoBehaviour
{
    public GameObject cubetoCopy;


    void Start()
    {
        MeshRenderer thismesh = this.gameObject.GetComponent<MeshRenderer>();
        thismesh.material.color = cubetoCopy.GetComponent<MeshRenderer>().material.color;

        //for the shader
        thismesh.material.SetColor("_Color", cubetoCopy.GetComponent<MeshRenderer>().material.color);
    }

    
}
