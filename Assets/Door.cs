using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public enum DoorDir { Up, Down, Left, Right }
public class Door : MonoBehaviour
{
    [ReadOnly] public Level level;
    [ReadOnly] public DoorDir dir;
    public Transform enterPosition;
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (level == null)
            {
                return;
            }
            switch (dir)
            {
                case DoorDir.Down:
                    {
                        LevelManager.instance.LoadLevel(level.downDirection, dir);
                        break;
                    }
                case DoorDir.Up:
                    {
                        LevelManager.instance.LoadLevel(level.upDirection, dir);
                        break;
                    }
                case DoorDir.Left:
                    {
                        LevelManager.instance.LoadLevel(level.leftDirection, dir);
                        break;
                    }
                case DoorDir.Right:
                    {
                        LevelManager.instance.LoadLevel(level.rightDirection, dir);
                        break;
                    }
            }
        }
    }
    public void Setup(DoorDir dir,Level l)
    {
        this.dir = dir;
        level = l;
    }
}
