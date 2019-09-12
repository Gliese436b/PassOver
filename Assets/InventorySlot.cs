using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
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

}
