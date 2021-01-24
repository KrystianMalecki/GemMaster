using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public static HeartDisplay instance;
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
    public enum HeartPart
    {
        full,
        empty
    }
    public Transform heartDisplayBox;
    public GameObject heartPrefab;
    public List<Image> hearts = new List<Image>();
    public Sprite full;
    public Sprite empty;

    int counter = 0;
    public void UpdateHP(int count, int max)
    {

        counter = 0;
        int fullCount = count;
        int emptyCount = max - count;

        while (max < hearts.Count)
        {
            Destroy(hearts[hearts.Count - 1].gameObject);
            hearts.RemoveAt(hearts.Count - 1);
        }

        for (int i = 0; i < fullCount; i++)
        {
            AddPart(HeartPart.full);
        }
        for (int i = 0; i < emptyCount; i++)
        {
            AddPart(HeartPart.empty);

        }
    }

    void AddPart(HeartPart hp)
    {
        while (counter >= hearts.Count)
        {
            GameObject go = Instantiate(heartPrefab, heartDisplayBox);
            hearts.Add(go.GetComponent<Image>());
        }
        switch (hp)
        {
            default:
            case HeartPart.empty:
                {
                    hearts[counter].sprite = empty;

                    break;
                }
            case HeartPart.full:
                {
                    hearts[counter].sprite = full;
                    break;
                }

        }
        counter++;
    }

}
