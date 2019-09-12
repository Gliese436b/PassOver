using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public delegate void FShowItemDetail(Image _itemImage, Text _itemName, Text _itemDescription);
    public static event FShowItemDetail OnShowDetail;

    public GameItem itemInSlot;
    public Image slotImage;
    public Text slotName;
    public Text slotDescription;

    public void Initialize()
    {
        if (itemInSlot == null) return;

        slotImage.sprite = itemInSlot.itemSprite;
        slotName.text = itemInSlot.itemName;
        slotDescription.text = itemInSlot.itemDescription;

        Debug.Log("Slot " + gameObject.name + " initialized.");
    }

    public void ShowItemDetail()
    {
        OnShowDetail?.Invoke(slotImage, slotName, slotDescription);
    }

}
