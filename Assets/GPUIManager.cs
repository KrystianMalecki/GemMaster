using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using CodeHelper;
using NaughtyAttributes;
public class GPUIManager : MonoBehaviour
{
    public static GPUIManager instance;
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
    public TextMeshProUGUI desc;
    public static Color cmdRed = new Color(1f, 0.6588235f, 0.6588235f);
    public static Color cmdBlue = new Color(0.6666667f, 0.9215686f, 1f);
    public static Color cmdGreen = new Color(0.7372549f, 1f, 0.6392157f);
    public static Color cmdYellow = new Color(1f, 0.8901961f, 0.5647059f);
    [Foldout("SlotBoxes")]
    public Transform slotBoxTransform;
    [Foldout("SlotBoxes")]
    public GameObject slotBoxPrefab;
    [Foldout("SlotBoxes")]
    public List<SlotBox> slotboxes = new List<SlotBox>();
    [Foldout("SlotBoxes")]

    [SerializeReference]
    public GemLogicBlock gemLogicBlock;

    public Sprite dataUp;
    public Sprite dataRight;
    public Sprite dataDown;
    public Sprite dataLeft;

    public Sprite dataOn;
    public Sprite dataOff;


    public bool open;

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
        open = true;
    }
    public void Hide()
    {
        open = false;

        if (gemLogicBlock == null)
        {
            return;
        }
        gemLogicBlock.gemBoxes.Clear();

        for (int i = 0; i < slotboxes.Count; i++)
        {
            slotboxes[i].Save();
            gemLogicBlock.gemBoxes.Add(slotboxes[i].referance);
        }
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
