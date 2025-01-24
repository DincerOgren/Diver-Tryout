using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUISlot : MonoBehaviour, IDropHandler
{
    // Hold item
    InventoryUIItem itemSlot;

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        print(transform.root.name);
        print("Sa");
        itemSlot = GetComponent<InventoryUIItem>();
    }



    // Swap Items?


    // AddToItem

    //RemoveFromItem

    //
}
