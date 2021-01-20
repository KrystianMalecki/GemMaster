using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float smoothTimex = 0.3f, smoothTimey = 0.2f;
    float xVelocity = 0.0f, yVelocity = 0.0f, newPositionx, newPositiony;

    void Update()
    {
        /*
        newPositionx = Mathf.SmoothDamp(transform.position.x, target.position.x, ref xVelocity, smoothTimex);
        newPositiony = Mathf.SmoothDamp(transform.position.y, Mathf.Sqrt(target.position.y * 3) + 2f, ref yVelocity, smoothTimey);
        transform.position = new Vector3(newPositionx, newPositiony, transform.position.z);
        */

        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
