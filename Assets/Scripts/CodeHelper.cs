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
        public static char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static float RandomBetween(this Vector2 v2)
        {

            return Mathf.Lerp(v2.x, v2.y, Random.Range(0f, 1f));
        }
        public static int RandomBetween(this Vector2Int v2)
        {

            return Mathf.RoundToInt(Mathf.Lerp(v2.x, v2.y, Random.Range(0f, 1f)));
        }
        public static string ColorForTMPro(this string str, Color c)
        {

            return "<color=#" + ColorUtility.ToHtmlStringRGB(c) + ">" + str + "</color>";
        }
        public static Vector2 GetDir(int a)
        {
            switch (a)
            {
                case 0:
                    {
                        return Vector2.up;
                    }
                case 1:
                    {
                        return Vector2.right;
                    }
                case 2:
                    {
                        return Vector2.down;
                    }
                case 3:
                    {
                        return Vector2.left;
                    }
            }
            return Vector2.up;
        }
    }
}
