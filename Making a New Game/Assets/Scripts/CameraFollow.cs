using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //public Transform Player;
    //private Vector3 FollowVector;
    //public Vector3 Offset;
    //void LateUpdate()
    //{
    //    FollowVector = Player.position - Offset;
    //    transform.position = Vector3.Lerp(transform.position, FollowVector, Time.deltaTime * 4f);
    //    transform.position = new Vector3(transform.position.x, -(Offset.y) ,transform.position.z);
    //}

    public Transform player;
    public Vector3 Offset;
    [Range(0.01f, 10)]
    public float smoothFactor;

    private Vector3 velocity = Vector3.zero;

	public void Awake()
	{
        //player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	private void LateUpdate()
	{

        Follow();

    }

    private void Follow()
	{
        
        Vector3 targetposition = player.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothFactor);
		//transform.position = new Vector3(transform.position.x, (Offset.y), transform.position.z);
		
    }
}
