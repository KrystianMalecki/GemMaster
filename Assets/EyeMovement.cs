using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovement : MonoBehaviour
{
    public Transform mainTransform;
    Vector2 eyeXrange = new Vector2(-0.125f, -0.0625f);
    Vector2 eyeYrange = new Vector2(0.125f, 0);
    public void Update()
    {
        transform.localPosition = new Vector3(
           (mainTransform.localScale.x==-1? (-0.0625f*3) : 0f)+
           mainTransform.localScale.x * Mathf.Lerp(eyeXrange.x, eyeXrange.y, Input.mousePosition.x / Camera.main.pixelWidth),
                        Mathf.Lerp(eyeYrange.x, eyeYrange.y,1- Input.mousePosition.y / Camera.main.pixelHeight),0);
    }
}
