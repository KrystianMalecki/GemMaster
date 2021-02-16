using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CodeHelper
{
    public static class CodeHelper
    {
        public static Vector2 ToVector2(this Vector3 v3)
        {
            return v3;
        }
        public static Vector3 ToVector3(this Vector2 v2)
        {
            return v2;
        }
        public static Vector3 AlignToPixel(this Vector3 v3)
        {

           // v3 = new Vector3(AlignFloatToPixel(v3.x), AlignFloatToPixel(v3.y), AlignFloatToPixel(v3.z));
            return new Vector3(AlignFloatToPixel(v3.x), AlignFloatToPixel(v3.y), AlignFloatToPixel(v3.z));
        }
        static float AlignFloatToPixel(float f)
        {
            return (Mathf.Round(f * 16f) / 16f);
        }
    }
}
