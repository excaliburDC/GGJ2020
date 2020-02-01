using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float cameraMovespeed=0.12f;
    [SerializeField]
    private Vector3 cameraOffset;

   


    private void LateUpdate()
    {
        Vector3 camPosition = playerTransform.position + cameraOffset;
        Vector3 camUpdatedPos = Vector3.Lerp(transform.position, camPosition, cameraMovespeed);
        

        transform.position = camUpdatedPos;

        transform.LookAt(playerTransform);
    }

}
