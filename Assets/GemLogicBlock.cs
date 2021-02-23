using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemLogicBlock : MonoBehaviour
{
    public List<CodeGem> gems = new List<CodeGem>();
    public List<LogicObject> objectsConnected = new List<LogicObject>();
    public void Execute()
    {
        for (int i = 0; i < gems.Count; i++)
        {
            for (int j = 0; j < objectsConnected.Count; j++)
            {
                gems[i].Execute(objectsConnected[j]);
        }
        }
    }
}
