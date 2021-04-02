using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GemBox
{
    public int data=0;
    public Gem functionGem = new Gem(GemType.FunctionGem,GemExecutionType.Move);
    public Gem numberGem = new Gem(GemType.FunctionGem, value:1);

}