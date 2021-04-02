using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomPropertyDrawer(typeof(Translation))]
public class TranslationDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.

        // Draw label
        // position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented

        // Calculate rects

        Rect part = new Rect(position.x, position.y, position.width / 4, position.height);
        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        GUI.Label(part, "Translation:");
        property.FindPropertyRelative("tag").stringValue = GUI.TextField(new Rect(part.x + part.width, part.y, part.width - 20, part.height), property.FindPropertyRelative("tag").stringValue);
        property.FindPropertyRelative("eng").stringValue = GUI.TextField(new Rect(part.x + 2 * part.width, part.y, part.width - 20, part.height), property.FindPropertyRelative("eng").stringValue);
        property.FindPropertyRelative("pl").stringValue = GUI.TextField(new Rect(part.x + 3 * part.width+10, part.y, part.width - 20, part.height), property.FindPropertyRelative("pl").stringValue);
        GUI.Label(new Rect(position.x + part.width - 30, position.y, position.width / 4, position.height), "Tag:");
        GUI.Label(new Rect(position.x + 2 * part.width - 20, position.y, position.width / 4, position.height), "PL");
        GUI.Label(new Rect(position.x + 3 * part.width - 20, position.y, position.width / 4, position.height), "ENG");


        // Set indent back to what it was

    }
}
