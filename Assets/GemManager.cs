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
    public List<Gem> collectedGems = new List<Gem>();
    public List<Color> variableColors = new List<Color>();

    [Foldout("Gem textures")] public List<Sprite> numberGemT= new List<Sprite>();
    [Foldout("Gem textures")] public Sprite moveGemT;
    [Foldout("Gem textures")] public Sprite toggleGemT;
    [Foldout("Gem textures")] public Sprite activateGemT;
    [Foldout("Gem textures")] public Sprite rotateGemT;
    [Foldout("Gem textures")] public Sprite functionGemT;

    public UIGem MakeUIGem(Gem gem, GemSlot slot)
    {
        GameObject go = Instantiate(uiGemPrefab, Vector3.zero, Quaternion.identity);
        UIGem uig = go.GetComponent<UIGem>();
        uig.Setup(gem, slot);
        return uig;
    }
    public Sprite GetTexture(Gem gem)
    {
        if (gem.type == GemType.FunctionGem)
        {
            switch (gem.executionType)
            {
                case GemExecutionType.Activate:
                    return activateGemT;
                case GemExecutionType.Toggle:
                    return toggleGemT;
                case GemExecutionType.Rotate:
                    return rotateGemT;
                case GemExecutionType.Function:
                    return functionGemT;
                case GemExecutionType.Move:
                    return moveGemT;
                default:
                    return null;
            }
        }else if(gem.type == GemType.NumberGem)
        {
            int index=gem.value;
            if (index < 0)
            {
                index = 0;
                //TODO: add color tinting
            }
            if (index > numberGemT.Count)
            {
                index = numberGemT.Count-1;
                Debug.LogWarning("Not enough textures!");
            }
            return numberGemT[index];
        }
        return null;//TODO: add logic
    }

}
