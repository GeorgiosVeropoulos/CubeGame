using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCheckPoint : MonoBehaviour
{
    public LevelManager levelmanager;
    public int cubeskilledchekpoint = 2;
    public GameObject checkpoint;
    public GameObject activatethis;
   
    // Start is called before the first frame update
    void Start()
    {
        checkpoint.SetActive(false);
        activatethis.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(levelmanager.CurrentCubesKilled == cubeskilledchekpoint)
		{
            checkpoint.SetActive(true);
		}
    }
	
}
