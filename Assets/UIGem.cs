using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIGem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static UIGem selected;
    [SerializeReference]
    public Gem gem;

    public Image icon;
    public bool isMovable = true;
    public GemSlot startSlot;
    public CanvasGroup cg;

    public RectTransform rt;
    public void Setup(Gem gem, GemSlot slot)
    {

        icon.sprite = gem.icon;
        this.gem = gem;
        startSlot = slot;
        if (gem.type == GemType.NumberGem)
        {
            rt.sizeDelta = new Vector2(51, 51);
        }
        GoBackToPlace(startSlot.transform);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        selected = this;

        GemInventoryUI.OnStartDragging.Invoke();

        GoBackToPlace(GameManager.instance.dragHead);

        cg.blocksRaycasts = false;
        Debug.Log("OnBeginDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.localPosition = eventData.position;
        Debug.Log("OnDrag");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GemInventoryUI.OnEndDragging.Invoke();

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
        startSlot?.ReturnGem();
    }
}
