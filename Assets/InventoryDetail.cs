using UnityEngine;
using UnityEngine.UI;

public class InventoryDetail : MonoBehaviour
{
    /// <summary>
    /// Parent of the whole shabang
    /// </summary>
    public GameObject screenObject;

    /// <summary>
    /// Picture that appears when the detail window is brought up
    /// </summary>
    public Image detailImage;

    /// <summary>
    /// Name for the detailed view
    /// </summary>
    public Text detailName;

    /// <summary>
    /// Description for the detailed view
    /// </summary>
    public Text detailDescription;

    private void OnEnable()
    {
        InventorySlot.OnShowDetail += InventorySlot_OnShowDetail;
    }

    private void OnDisable()
    {
        InventorySlot.OnShowDetail -= InventorySlot_OnShowDetail;
    }

    /// <summary>
    /// Implementacion del evento OnShowDetail, que activa los elementos del detail ui y pasa las referencias.
    /// </summary>
    /// <param name="item">Scriptable Object, contiene toda la informacion necesaria para el detail ui.</param>
    private void InventorySlot_OnShowDetail(GameItem item)
    {
        if (item == null) return;

        screenObject.SetActive(true);

        detailImage.enabled = true;
        detailImage.sprite = item.itemSprite;

        detailName.enabled = true;
        detailName.text = item.itemName;

        detailDescription.enabled = true;
        detailDescription.text = item.itemDescription;
    }

    /// <summary>
    /// Apagar los componentes y el gameObject
    /// </summary>
    public void CloseDetail()
    {
        detailImage.enabled = false;
        detailName.enabled = false;
        detailDescription.enabled = false;

        screenObject.SetActive(false);
    }
}
