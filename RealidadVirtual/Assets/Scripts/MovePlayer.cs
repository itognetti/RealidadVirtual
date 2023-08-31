using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform target;            
    public float smoothSpeed = 0.1f;  
    public Vector3 offset = new Vector3(-1, 0, -1);

    private bool isFollowing = false; 

    private void Update()
    {
        if (target.GetComponent<Rigidbody>().velocity.magnitude <= 0.1f)
        {
            isFollowing = true;  
        }
    }

    private void LateUpdate()
    {
        if (isFollowing)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            // transform.LookAt(target);
            isFollowing = false;
        }
    }

}
