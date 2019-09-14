using TMPro;
using UnityEngine;

public class UINotifyButton : MonoBehaviour
{
    public GameObject button;
    public TMP_Text text;
    public GameObject infoBox;
    public TMP_Text infoText;
    PlayerController player;

    public string textItem = "CLIMB";
    public string textChar = "HIDE";
    public string textDoor = "USE SWITCH";

    private void Awake()
    {
        button.SetActive(false);
    }

    private void OnEnable()
    {
        InteractBase.OnNotifyInteract += InteractBase_OnNotifyInteract;
    }

    private void OnDisable()
    {
        InteractBase.OnNotifyInteract -= InteractBase_OnNotifyInteract;
    }

    private void InteractBase_OnNotifyInteract(ETypeOfInteract _typeOfInteract, bool _onOff, PlayerController _player)
    {
        player = _player;
        button.SetActive(_onOff);
        if (!_onOff) return;
        switch (_typeOfInteract)
        {
            case ETypeOfInteract.DOOR:
                text.text = textDoor;
                break;
            case ETypeOfInteract.ITEM:
                text.text = textItem;
                break;
            case ETypeOfInteract.CHAR:
                text.text = textChar;
                break;
            default:
                break;
        }
    }
}
