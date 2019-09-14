using UnityEngine;
using UnityEngine.UI;

public class InventorySlot:MonoBehaviour
{
    public delegate void FShowItemDetail(GameItem item);
    public static event FShowItemDetail OnShowDetail;

    /// <summary>
    /// Scriptable that contains the item info.
    /// </summary>
    public GameItem itemInSlot;

    /// <summary>
    /// UI image of the item that shows up in the slot.
    /// </summary>
    public Image slotImage;

    /// <summary>
    /// UI Text that shows the name of the item.
    /// </summary>
    public Text slotName;

    /// <summary>
    /// Button component of the slot.
    /// </summary>
    public Button button;

    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Sets up the UI for use. Called on Start and when the menu is brought up.
    /// </summary>
    public void Initialize()
    {
        if (itemInSlot == null)
        {
            button.interactable = false;
            return;
        }
        
        button.interactable = true;

        slotImage.sprite = itemInSlot.itemSprite;
        slotName.text = itemInSlot.itemName;

        //Debug.Log("Slot " + gameObject.name + " initialized.");
    }

    /// <summary>
    /// Public method for calling the OnShowDetail event.
    /// </summary>
    public void ShowItemDetail()
    {
        OnShowDetail?.Invoke(itemInSlot);
    }

}
