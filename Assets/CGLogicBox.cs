using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGLogicBox : MonoBehaviour
{
    public List<CodeGem> gems = new List<CodeGem>();
    public void Activate()
    {
        for (int i = 0; i < gems.Count; i++)
        {
            gems[i].Execute();
        }
    }
    //Add some logic? for logic box
}
