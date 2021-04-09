using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public static LogicManager instance;
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
    //storing functions?


    //maybe change string to enum or some other data storage
    //maybe change it to new class?
    public List<int> variables = new List<int>();
   
}
