using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemLogicBlock : MonoBehaviour
{
    public List<CodeGem> gems = new List<CodeGem>();
    public List<LogicObject> objectsConnected = new List<LogicObject>();
    public void Execute()
    {
     
        StartCoroutine(ExecuteOrder());
    }
  
    int bufferstater;
    IEnumerator ExecuteOrder()
    {
        for (int i = 0; i < gems.Count; i++)
        {
            bufferstater = 0;
            for (int j = 0; j < objectsConnected.Count; j++)
            {
                gems[i].Execute(objectsConnected[j],this);
            }
        
            yield return new WaitUntil(() => bufferstater == objectsConnected.Count);
          
        }
       
    }
   
    public void HalfMTTNS()
    {
        bufferstater++;
    }
}
