using UnityEngine;
using UnityEngine.UI;

public class InventoryDetail : MonoBehaviour
{
    public GameObject screenObject;
    public Image detailImage;
    public Text detailName;
    public Text detailDescription;

    private void OnEnable()
    {
        InventorySlot.OnShowDetail += InventorySlot_OnShowDetail;
    }

    private void OnDisable()
    {
        InventorySlot.OnShowDetail -= InventorySlot_OnShowDetail;
    }

    private void InventorySlot_OnShowDetail(Image _itemImage, Text _itemName, Text _itemDescription)
    {
        screenObject.SetActive(true);

        detailImage.enabled = true;
        detailImage.sprite = _itemImage.sprite;

        detailName.enabled = true;
        detailName.text = _itemName.text;

        detailDescription.enabled = true;
        detailDescription.text = _itemDescription.text;
    }

    public void CloseDetail()
    {
        detailImage.enabled = false;
        detailName.enabled = false;
        detailDescription.enabled = false;

        screenObject.SetActive(false);
    }
}
