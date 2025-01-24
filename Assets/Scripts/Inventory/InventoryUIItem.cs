using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventoryUIItem : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    // ItemClass? SO?
    [SerializeField] Canvas canvas;
    [SerializeField] Transform carryParent;
    public MaterialSO1 item;
    Image image;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;

    Transform originalParent;

    private void Awake()
    {
        image = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = transform.root.GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        originalParent = transform.parent;
        carryParent = GameObject.FindWithTag("CarryParent").transform;
    }

    private void Start()
    {
        Initialize();
    }



    private void Initialize()
    {
        if (item==null)
        {
            gameObject.SetActive(false);
            return;
        }

        image.sprite = item.materialImage;
        gameObject.SetActive(true);
    }

    //IsStackable?

    public bool IsStackable() => item.isStackable;

    //Get Item

    public MaterialSO1 GetItem() => item;
    // Set Item

    public void SetItem(MaterialSO1 newItem)
    {
        item = newItem; Initialize();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("BeginDrag");
        ChangeParent(carryParent);
        canvasGroup.blocksRaycasts = false;
    }

    private void ChangeParent(Transform parent)
    {
        if(parent != null)
        {
            transform.SetParent(parent);
            Debug.Log(gameObject.name + " simdi " + parent.name + " objesinin cocuðu oldu.");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        print("OnDrag");

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        ChangeParent(originalParent);
        print("EndDrag");

    }


}
