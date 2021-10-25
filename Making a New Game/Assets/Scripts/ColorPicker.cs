using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{

    //public GameObject thiscube;
    
    public MeshRenderer meshrend;
    public Color _color;
   
    
    
    // Start is called before the first frame update
    public void Awake()
    {
        
        //thiscube = this.gameObject;
        //counter = GetComponent<Counter>();
        if(meshrend == null)
		{
            meshrend = this.gameObject.GetComponent<MeshRenderer>();
        }
        int randomcolorstart = (int)Random.Range(1, 5);
        if (randomcolorstart == 1)
        {
            meshrend.material.color = Color.red;
            _color = Color.red;
            meshrend.material.SetColor("_Color", Color.red);
        }
        else if (randomcolorstart == 2)
        {
            meshrend.material.color = Color.blue;
            _color = Color.blue;
            meshrend.material.SetColor("_Color", Color.blue);
        }
        else if (randomcolorstart == 3)
        {
            meshrend.material.color = Color.green;
            _color = Color.green;
            meshrend.material.SetColor("_Color", Color.green);
        }
        else if (randomcolorstart == 4)
        {
            meshrend.material.color = Color.yellow;
            _color = Color.yellow;
            meshrend.material.SetColor("_Color", Color.yellow);
        }
    }


    private void Start()
    {
        
       
    }
    // Update is called once per frame
    public  void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "Player")
		{
            

            //Destroy(this.gameObject);
            //Instantiate(thiscube);
            

        }
        
        
    }
}

