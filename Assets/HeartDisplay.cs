using System.Collections;
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
            DontDestroyOnLoad(gameObject);
        }
    }
    public enum HeartPart { 
    full,
    half,
    empty

    }
    public Transform heartDisplayBox;
    public GameObject heartPrefab;
    public List<Image> hearts = new List<Image>();
    public Sprite full;
    public Sprite half;
    public Sprite empty;

    int counter = 0;
   public void UpdateHP(int count,int max)
    {
        
        counter = 0;
        bool half = count % 2 == 1;
        int fullCount =  count / 2;
  
        int emptyCount = max / 2 - fullCount-(half?1:0);

        for (int i = 0; i < fullCount ; i++)
        {
            AddPart(HeartPart.full);
        }
        if (half)
        {
            AddPart(HeartPart.half);

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
            hearts.Add( go.GetComponent<Image>());
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
            case HeartPart.half:
                {
                    hearts[counter].sprite = half;
                    break;
                }
        }
        counter++;
    }
}
