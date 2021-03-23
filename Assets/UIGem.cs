using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIGem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static UIGem selected;
    public CodeGem gem;
    
    public Image icon;
    public bool isMovable=true;
     public GemSlot startSlot;
    public CanvasGroup cg;

    
    public void Setup(CodeGem gem, GemSlot slot)
    {
       
        icon.sprite = gem.image;
        this.gem = gem;
        startSlot = slot;
      
        GoBackToPlace(startSlot.transform);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        selected = this;

      

        GoBackToPlace(GameManager.instance.dragHead);

        cg.blocksRaycasts = false;
        Debug.Log("OnBeginDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        Debug.Log("OnDrag");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = true;
        //  this.transform.parent = startPosition;
        GoBackToPlace(startSlot.transform);

        selected = null;
        Debug.Log("OnEndDrag");

    }
    public void AddToSlot(GemSlot slot)
    {
        startSlot = slot;
        GoBackToPlace(startSlot.transform);
    }
    public void GoBackToPlace(Transform trr)
    {
        transform.SetParent(trr);
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;
    }
}
