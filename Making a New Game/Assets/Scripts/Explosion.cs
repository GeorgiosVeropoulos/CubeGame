using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    public GameObject manager;
    float cubesPivotDistance;
    Vector3 cubesPivot;
    public GameObject prefab;
    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager");
        
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

    }

    

    
	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.name == "Player")
        {
            MeshRenderer thismeshrend = this.gameObject.GetComponent<MeshRenderer>();
            MeshRenderer playermeshrend = collision.gameObject.GetComponent<MeshRenderer>();
            if (thismeshrend.material.color == playermeshrend.material.color)
			{
                explode();
                manager.GetComponent<LevelManager>().CurrentCubesKilled++;
                
                Debug.Log("Cubes killed so far" + manager.GetComponent<LevelManager>().CurrentCubesKilled);
                Destroy(this.gameObject);
            }
			else
			{
                this.GetComponent<BoxCollider>().isTrigger = true;
			}
            
        }
    }
	private void OnTriggerExit(Collider other)
	{
        this.GetComponent<BoxCollider>().isTrigger = false;
    }


	public void explode()
    {
        //make object disappear
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z)
    {

        //create piece
        //GameObject piece;
        //piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject piece2;
        piece2 = GameObject.Instantiate(prefab);
        //set piece position and scale
        piece2.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece2.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        //piece2.AddComponent<Rigidbody>();
        piece2.GetComponent<Rigidbody>().mass = cubeSize;
    }
}
