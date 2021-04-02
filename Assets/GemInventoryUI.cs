using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening.Core;
using DG.Tweening;
using UnityEngine.UI;
using CodeHelper;
public class GemInventoryUI : MonoBehaviour
{


    public GameObject prefab;
    public Transform mainGemsTransform;


    public RectTransform rect;
    public List<GemSlot> mainGemSlots = new List<GemSlot>();
    public List<GemSlot> countGemSlots = new List<GemSlot>();

    public Image arrow;
    public Sprite left;
    public Sprite right;

    public Image red;
    public Image green;
    public Image blue;
    Color cred;
    Color cgreen;
    Color cblue;
    public void SetupGems()
    {
        List<Gem> maingems = GemManager.instance.collectedGems.FindAll(x => x.type == GemType.FunctionGem);
        List<Gem> countgems = GemManager.instance.collectedGems.FindAll(x => x.type == GemType.NumberGem);

        SetupGemsType(mainGemsTransform, maingems, ref mainGemSlots);
        SetupGemsType(mainGemsTransform, countgems, ref countGemSlots);

    }
    public void SetupGemsType(Transform tr, List<Gem> list, ref List<GemSlot> slots)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < list.Count)
            {
                slots[i].Setup(list[i], i);
            }
            else
            {
                slots[i].Hide();
            }
        }
        for (int i = slots.Count; i < list.Count; i++)
        {
            GameObject go = Instantiate(prefab, tr);
            GemSlot gems = go.GetComponent<GemSlot>();
            gems.Setup(list[i], i);
            slots.Add(gems);
        }
    }
    public void Start()
    {
        SetupGems();
        isOpen = true;
        Open();
        cred = red.color;
        cgreen = green.color;
        cblue = blue.color;
    }
    public static UnityEvent OnStartDragging = new UnityEvent();
    public static UnityEvent OnEndDragging = new UnityEvent();
    public void ToggleSlots(List<GemSlot> slots, bool on)
    {

        if (on)
        {
            foreach (GemSlot item in slots)
            {
                item.Show();
            }
        }
        else
        {
            foreach (GemSlot item in slots)
            {
                item.Hide();
            }
        }

    }
    public bool isOpen;
    public void Toggle()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            arrow.sprite = left;
            Open();
        }
        else
        {
            arrow.sprite = right;

            Hide();
        }

    }
    public void Open()
    {
        rect.DOLocalMoveX(550f, 0.8f).SetEase(Ease.InOutBack);

    }
    public void Hide()
    {
        rect.DOLocalMoveX(266f, 0.8f).SetEase(Ease.InOutBack);
    }

    public void ToggleType(GemType type)
    {
        rect.DOLocalMoveX(266f, 0.4f).SetEase(Ease.InOutQuad).OnComplete(() => { tt2(type); });


    }
    void tt2(GemType type)
    {
        /*   mainGemsTransform.gameObject.SetActive(false);
           countGemsTransform.gameObject.SetActive(false);
           functionGemsTransform.gameObject.SetActive(false);
        */
        switch (type)
        {
            case GemType.DataGem:
                {
                    ToggleSlots(mainGemSlots, false);
                    ToggleSlots(countGemSlots, false);
                    //  functionGemsTransform.gameObject.SetActive(true);
                    break;
                }
            case GemType.FunctionGem:
                {
                    ToggleSlots(mainGemSlots, true);
                    ToggleSlots(countGemSlots, false);
                    //  mainGemsTransform.gameObject.SetActive(true);
                    break;
                }
            case GemType.NumberGem:
                {
                    ToggleSlots(mainGemSlots, false);
                    ToggleSlots(countGemSlots, true);
                    // countGemsTransform.gameObject.SetActive(true);
                    break;
                }
        }
        rect.DOLocalMoveX(550f, 0.4f).SetEase(Ease.InOutQuad);

    }
    public void t(int a)
    {
        switch (a)
        {
            case 0:
                {
                    red.color = cred;
                    blue.color = cblue * 0.7f;
                    green.color = cgreen;

                    ToggleType(GemType.FunctionGem);
                    break;
                }
            case 1:
                {
                    red.color = cred;
                    blue.color = cblue;
                    green.color = cgreen * 0.7f;

                    ToggleType(GemType.NumberGem);
                    break;
                }

        }
    }
}
