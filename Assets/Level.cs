using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public List<int> variables = new List<int>();
    //TODO: add listener to remove them from data

    public List<PickupObject> pickups = new List<PickupObject>();
    public List<GemLogicBlock> GLBs = new List<GemLogicBlock>();

    //TODO: add directional tunnels?
    //TODO: add aniamtions
    //TODO: add spawning enemies
    [HorizontalLine]

    public LevelData levelData = new LevelData();

    [HorizontalLine]
    [Header("Exits and entrances")]
    [Foldout("Up")] public Door upDoor;
    [Foldout("Up")] public LevelTag upDirection;

    [Foldout("Down")] public Door downDoor;
    [Foldout("Down")] public LevelTag downDirection;

    [Foldout("Left")] public Door leftDoor;
    [Foldout("Left")] public LevelTag leftDirection;

    [Foldout("Right")] public Door rightDoor;
    [Foldout("Right")] public LevelTag rightDirection;

    public EndManager em;

    public void Awake()
    {
        for (int i = 0; i < pickups.Count; i++)
        {
            pickups[i].Setup(this, i);
        }
        upDoor?.Setup(DoorDir.Up, this);
        downDoor?.Setup(DoorDir.Down, this);
        leftDoor?.Setup(DoorDir.Left, this);
        rightDoor?.Setup(DoorDir.Right, this);


    }

    public void Start()
    {
        LoadLevel();

    }
    public void LoadLevel()
    {

        gameObject.SetActive(true);
        LogicManager.instance.variables = variables;
        for (int i = 0; i < levelData.pickupIds.Count; i++)
        {
            pickups[levelData.pickupIds[i]].gameObject.SetActive(false);
        }
        for (int i = 0; i < levelData.glbdatas.Count; i++)
        {

            GLBs[i].gemBoxes = levelData.glbdatas[i].gemBoxes;
            GLBs[i].gemBoxes.ForEach(x => Debug.Log(x.ToString()));
        }
        em?.Count();
    }
    public void UnLoadLevel()
    {

        SaveData();
        gameObject.SetActive(false);
        LogicManager.instance.variables.Clear();
    }
    public void SaveData()
    {
        levelData.glbdatas.Clear();
        for (int i = 0; i < GLBs.Count; i++)
        {
           // GLBs[i].gemBoxes.ForEach(x => Debug.LogError(x.ToString()));
            levelData.glbdatas.Add(new GLBData(GLBs[i].gemBoxes));

        }
    }
    public void Pickuped(int id)
    {
        levelData.pickupIds.Add(id);
    }

}
