using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class WireConnector : MonoBehaviour
{
    //Add Wire connector logic
    public Transform end;
    public Transform start;
    public LineRenderer lr;
    [Button("Generate start-end")]
    public void UpdateLine()
    {
        lr.SetPosition(0, start.position);
        //bezier hanging-rope logic maybe?
        lr.SetPosition(lr.positionCount - 1, end.position);
        
    }
    private void Update() // quick fix, add Listener/Event to movable block to trigger UpdateLine()
    {
        if (end.hasChanged || start.hasChanged)
        {
            UpdateLine();
        }
    }
}
