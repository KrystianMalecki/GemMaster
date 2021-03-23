using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour
{
    public static GemManager instance;
    void Awake()
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
    [Foldout("Prefabs")] public GameObject uiGemSlotPrefab;
    [Foldout("Prefabs")] public GameObject uiGemPrefab;
    public List<CodeGem> collectedGems = new List<CodeGem>();
    public UIGem MakeUIGem(CodeGem cg, GemSlot slot)
    {
        GameObject go = Instantiate(uiGemPrefab, Vector3.zero, Quaternion.identity);
        UIGem uig = go.GetComponent<UIGem>();
        uig.Setup(cg, slot);
        return uig;
    }
}
