using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public enum EUIState { ENABLED, DISABLED }

    private PlayerController player;
    public ItemInventory inventory;
    public GameObject inventoryObject;
    public EUIState currUIState;
    public List<InventorySlot> slots = new List<InventorySlot>();

    private void Awake()
    {

    }

    private void Start()
    {
        SortInventory();
    }

    private void SortInventory()
    {
        for (int i = 0; i < inventory.itemsInInventory.Count; i++)
        {
            if (inventory.itemsInInventory[i] == null)
            {
                break;
            }

            if (slots[i].itemInSlot == null)
            {
                slots[i].itemInSlot = inventory.itemsInInventory[i];
                slots[i].Initialize();
            }
        }
    }

    private void OnEnable()
    {
        PlayerController.OnActivate += PlayerControl_OnActivate;
    }

    private void OnDisable()
    {
        PlayerController.OnActivate -= PlayerControl_OnActivate;
    }

    private void PlayerControl_OnActivate(PlayerController _player)
    {
        player = _player;
    }

    private void Update()
    {
        if (player == null) return;

        if (player.bUseInventory)
        {
            ToggleUI();
            SortInventory();
        }
    }

    void ToggleUI()
    {
        switch (currUIState)
        {
            case EUIState.ENABLED:

                inventoryObject.SetActive(false);
                currUIState = EUIState.DISABLED;

                break;

            case EUIState.DISABLED:

                inventoryObject.SetActive(true);
                currUIState = EUIState.ENABLED;

                break;

            default:

                break;
        }
    }
}
