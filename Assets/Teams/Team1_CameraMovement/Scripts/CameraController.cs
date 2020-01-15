using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public GameObject objectToFollow;
    //public float followSpeed = 5f;

    public Transform player;

    private Transform myTransform;
    private Vector3 offset = Vector3.zero;

    void Start()
    {
        //if (objectToFollow == null)
        //    objectToFollow = FindObjectOfType<PlayerMovement>().gameObject;

        myTransform = transform;
        offset = player.position + myTransform.position;
    }

    void Update()
    {
        //Vector3 targetPosition = objectToFollow.transform.position;
        //Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        //transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
        myTransform.position = player.position + offset;
    }
}
