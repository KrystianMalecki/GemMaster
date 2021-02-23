using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class EyeMovement : MonoBehaviour
{
    [Foldout("Static Data")] public Transform mainTransform;
    //Vector2 eyeXrange = new Vector2(-0.125f, -0.0625f);
    //Vector2 eyeYrange = new Vector2(0.125f, 0);
    float eyeY, eyeX;

    public void Update()
    {
        /*transform.localPosition = new Vector3(
           (mainTransform.localScale.x==-1? (-0.0625f*3) : 0f)+
           mainTransform.localScale.x * Mathf.Lerp(eyeXrange.x, eyeXrange.y, Input.mousePosition.x / Camera.main.pixelWidth),
                        Mathf.Lerp(eyeYrange.x, eyeYrange.y,1- Input.mousePosition.y / Camera.main.pixelHeight),0);*/

        if (Input.mousePosition.x / Camera.main.pixelWidth > 0.5f)
        {
            eyeX = -0.0625f;
        }
        else
        {
            eyeX = -0.125f;
        }

        if(Input.mousePosition.y / Camera.main.pixelHeight > 0.66f)
        {
            eyeY = 0.125f;
        }
        else if(Input.mousePosition.y / Camera.main.pixelHeight > 0.33f)
        {
            eyeY = 0.0625f;
        }
        else
        {
            eyeY = 0;
        }

        transform.localPosition = new Vector3(
          (mainTransform.localScale.x == -1 ? (-0.0625f * 3) : 0f) +
          mainTransform.localScale.x * eyeX, eyeY, 0);
    }
}
