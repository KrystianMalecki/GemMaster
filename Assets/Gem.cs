using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public enum GemType { FunctionGem, NumberGem, DataGem }
public enum GemExecutionType { Move, Rotate, Toggle, Activate, Function }
[System.Serializable]
public class Gem
{
    private Sprite image;
    public GemType type;
    [AllowNesting]
    [ShowIf("function")] public GemExecutionType executionType;

    [AllowNesting]
    [ShowIf("number")] public int value;
    bool function => type == GemType.FunctionGem;
    bool number => type == GemType.NumberGem;
    public int GetValue()
    {
        //TODO: add getting value from variables
        return value;
    }
    public Gem(GemType type, GemExecutionType executionType = GemExecutionType.Move, int value = -1)
    {
        this.type = type;
        this.executionType = executionType;
        this.value = value;
    }
    public Sprite icon
    {
        get
        {
            if (image == null)
            {
                image = GemManager.instance.GetTexture(this);
            }
            return image;
        }
        set
        {
            image = value;
        }
    }
}
