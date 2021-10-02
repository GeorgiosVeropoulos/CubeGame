using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;
    private Vector3 FollowVector;
    public Vector3 Offset;
    void LateUpdate()
    {
        FollowVector = Player.position - Offset;
        transform.position = Vector3.Lerp(transform.position, FollowVector, Time.deltaTime * 4f);
        transform.position = new Vector3(transform.position.x, -(Offset.y) ,transform.position.z);
    }
}
