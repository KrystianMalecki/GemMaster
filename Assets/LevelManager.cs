using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LevelTag { none, tutorial, debug, debug2, templeout, temple2, hubworld }

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
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
    public bool debug;
    public PlayerScript player;
    public FollowerMovement follower;
    public List<Level> levels = new List<Level>();
    public static Level currentLevel;
    public static DoorDir currentDir;

    public BlurManager blur;
    public void LoadLevel(LevelTag newLeveltag, DoorDir from)
    {
        if (newLeveltag == LevelTag.none)
        {
            Debug.LogError("CAn't find level with tag " + newLeveltag.ToString());

            return;
        }
        blur.ToggleBlur(true, true);
        StartCoroutine(mid(newLeveltag, from));
        currentDir = from;

    }
    IEnumerator end()
    {
        yield return new WaitForSeconds(0.5f);
        blur.ToggleBlur(false, true);
    }
    IEnumerator mid(LevelTag newLeveltag, DoorDir from)
    {
        yield return new WaitForSeconds(0.5f);
        currentLevel?.UnLoadLevel();
        Level newLevel = levels.Find(x => x.levelData.tagName == newLeveltag);
        if (newLevel == null)
        {
            Debug.LogError("CAn't find level with tag " + newLeveltag.ToString());
        }
        newLevel.LoadLevel();
        Vector2 vel = player.ridgidBody2D.velocity;
        switch (from)
        {
            case DoorDir.Down:
                {
                    if (newLevel.upDoor == null)
                    {
                        Debug.LogError("No corresponding door!");
                    }
                    player.transform.position = newLevel.upDoor.enterPosition.position;
                    follower.transform.position = newLevel.upDoor.transform.position;
                    player.ridgidBody2D.AddForce(Vector2.down * 5f);
                    break;
                }
            case DoorDir.Up:
                {
                    if (newLevel.downDoor == null)
                    {
                        Debug.LogError("No corresponding door!");
                    }
                    player.transform.position = newLevel.downDoor.enterPosition.position;
                    follower.transform.position = newLevel.downDoor.transform.position;
                    player.ridgidBody2D.AddForce(Vector2.up * 5f);
                    break;
                }
            case DoorDir.Left:
                {
                    if (newLevel.rightDoor == null)
                    {
                        Debug.LogError("No corresponding door!");
                    }
                    player.transform.position = newLevel.rightDoor.enterPosition.position;
                    follower.transform.position = newLevel.rightDoor.transform.position;
                    player.ridgidBody2D.AddForce(Vector2.left * 5f);
                    break;
                }
            case DoorDir.Right:
                {
                    if (newLevel.leftDoor == null)
                    {
                        Debug.LogError("No corresponding door!");
                    }
                    player.transform.position = newLevel.leftDoor.enterPosition.position;
                    follower.transform.position = newLevel.leftDoor.transform.position;
                    player.ridgidBody2D.AddForce(Vector2.right * 5f);
                    break;
                }
        }

        player.ridgidBody2D.velocity = vel;
        currentLevel = newLevel;
        StartCoroutine(end());
    }
    public void Start()
    {
        if (!debug)
        {
            foreach (Level l in levels)
            {
                l.UnLoadLevel();
            }
            LoadLevel(SaveManager.instance.currentSave.lastLvl, SaveManager.instance.currentSave.lastDir);
            player.StartCoroutine(player.e());
        }
        else
        {
            player.StartCoroutine(player.e());


        }
    }
}
