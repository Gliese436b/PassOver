using TMPro;
using UnityEngine;

public class UINotifyButton : MonoBehaviour
{
    public GameObject button;
    public TMP_Text text;
    public GameObject infoBox;
    public TMP_Text infoText;
    PlayerControl player;

    public string textLadder = "CLIMB";
    public string textLadderLeave = "STEP OFF";
    public string textShadow = "HIDE";
    public string textLeaveShadow = "LEAVE";
    public string textSwitch = "USE SWITCH";
    public string textExit = "NEXT AREA";

    public string textDNACling = "PICK UP REVERSE LATCH";
    public string textDNATrick = "PICK UP INFLUENCE";
    public string textDNATrap = "PICK UP WOVEN TRAP";

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

    private void InteractBase_OnNotifyInteract(ETypeOfInteract _typeOfInteract, bool _onOff, PlayerControl _player)
    {
        player = _player;
        button.SetActive(_onOff);
        if (!_onOff) return;
        switch (_typeOfInteract)
        {
            case ETypeOfInteract.DOOR:
                text.text = textSwitch;
                break;
            case ETypeOfInteract.ITEM:
                text.text = textLadder;
                break;
            case ETypeOfInteract.CHAR:
                text.text = textShadow;
                break;
            default:
                break;
        }
    }
}
