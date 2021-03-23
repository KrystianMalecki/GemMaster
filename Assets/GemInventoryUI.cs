using System.Collections.Generic;
using UnityEngine;

public class GemInventoryUI : MonoBehaviour
{
    public GameObject prefab;
    public Transform tr;
    public List<GemSlot> gemSlots = new List<GemSlot>();
    public void SetupGems()
    {
        
        for (int i = 0; i < gemSlots.Count; i++)
        {
            if(i< GemManager.instance.collectedGems.Count)
            {
                gemSlots[i].Setup(GemManager.instance.collectedGems[i],i);
            }
            else
            {
                gemSlots[i].Hide();
            }
        }
        for(int i= gemSlots.Count;i< GemManager.instance.collectedGems.Count; i++)
        {
            GameObject go = Instantiate(prefab, tr);
            GemSlot gems = go.GetComponent<GemSlot>();
            gems.Setup(GemManager.instance.collectedGems[i], i);
            gemSlots.Add(gems);
        }
        

    }
    public void Start()
    {
        SetupGems();
    }
}
