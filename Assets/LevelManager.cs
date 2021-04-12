using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum LevelTag { none, tutorial, debug, debug2, templeout, temple2, hubworld, end }

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

    public UnityEvent LevelChange = new UnityEvent();
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    public GameObject go4;
    int count = 0;
    bool b = false;

    public void LoadLevel(LevelTag newLeveltag, DoorDir from)
    {

        if (newLeveltag == LevelTag.tutorial)
        {
            if (!PlayerPrefs.HasKey("Comic"))
            {
                PlayerPrefs.SetInt("Comic", 0);
                b = true;
            }
        }
        if (newLeveltag == LevelTag.none)
        {
            Debug.LogError("CAn't find level with tag " + newLeveltag.ToString());

            return;
        }
        blur.ToggleBlur(true, true);
        StartCoroutine(mid(newLeveltag, from));
        currentDir = from;

    }
    public void Update()
    {
        if (b)
        {
            if (count == 0)
            {
                go1.SetActive(true);
            }
            else if (count == 1)
            {
                go2.SetActive(true);

            }
            else if (count == 2)
            {
                go3.SetActive(true);

            }
            else if (count == 3)
            {
                go4.SetActive(true);

            }
            else
            {
                go1.SetActive(false);
                go2.SetActive(false);
                go3.SetActive(false);
                go4.SetActive(false);
                b = false;
            }
            if (Input.GetMouseButtonDown(0))
            {

                count++;
            }
        }
    }
    IEnumerator end()
    {
        yield return new WaitForSeconds(0.5f);
        blur.ToggleBlur(false, true);
    }
    IEnumerator mid(LevelTag newLeveltag, DoorDir from)
    {
        yield return new WaitForSeconds(0.5f);
        follower.targetBAP?.deattach();
        follower.Deattach();
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
        LevelChange.Invoke();

        StartCoroutine(end());
    }
    public void Start()
    {
        go1.SetActive(false);
        go2.SetActive(false);
        go3.SetActive(false);
        go4.SetActive(false);
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
