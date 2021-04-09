using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using CodeHelper;
using NaughtyAttributes;
public class GPUIManager : MonoBehaviour
{
    public TextMeshProUGUI desc;
    public Color cmdRed;
    public Color cmdBlue;
    public Color cmdGreen;
    public Color cmdYellow;
    [Foldout("SlotBoxes")]
    public Transform slotBoxTransform;
    [Foldout("SlotBoxes")]
    public GameObject slotBoxPrefab;
    [Foldout("SlotBoxes")]
    public List<SlotBox> slotboxes = new List<SlotBox>();
    [Foldout("SlotBoxes")]

    [SerializeReference]
    public GemLogicBlock gemLogicBlock;
    public void Start()
    {
        //TODO: add full desc
        desc.text = TranslationManager.instance.Translate("{type} = {gem};\n").ColorForTMPro(cmdRed);
    }
    public void Open(GemLogicBlock glb)
    {
        gameObject.SetActive(true);
        gemLogicBlock = glb;
        LoadGems();
    }
    public void Hide()
    {
        gameObject.SetActive(false);

    }
    public void LoadGems()
    {
        for (int i = 0; i < slotboxes.Count; i++)
        {
            if (i < gemLogicBlock.gemBoxes.Count)
            {
                slotboxes[i].Setup(gemLogicBlock.gemBoxes[i], i);
            }
            else
            {
                slotboxes[i].Hide();
            }
        }
        for (int i = slotboxes.Count; i < gemLogicBlock.gemBoxes.Count; i++)
        {
            GameObject go = Instantiate(slotBoxPrefab, slotBoxTransform);
            SlotBox sb = go.GetComponent<SlotBox>();
            sb.Setup(gemLogicBlock.gemBoxes[i], i);
            slotboxes.Add(sb);
        }
    }
}
