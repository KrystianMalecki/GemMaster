using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    //storing functions?


    //maybe change string to enum or some other data storage
    //maybe change it to new class?
    public Dictionary<string, int> variables = new Dictionary<string, int>();
    public int GetVariable(string str)
    {
        return variables[str];
    }
    public void SetVariable(string str,int value)
    {
        variables[str] = value;
    }
}
