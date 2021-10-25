using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dither : MonoBehaviour
{
    private MeshRenderer mesh;
    public bool Dithering = false;
    public bool Beinghit = false;
    // Start is called before the first frame update
    void Start()
    {
        mesh = this.gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Dithering == true)
		{
            mesh.material.SetFloat("_Opacity", 0.5f);
		}
		else
		{
            mesh.material.SetFloat("_Opacity", 1f);
        }

        //Dithering = false;
    }
}
