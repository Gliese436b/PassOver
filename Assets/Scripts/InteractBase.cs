using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ETypeOfInteract { DOOR, ITEM, CHAR };

public abstract class InteractBase : MonoBehaviour
{
    public delegate void FNotifyInteract(ETypeOfInteract _typeOfInteract, bool _onOff, PlayerControl _player);
    public static event FNotifyInteract OnNotifyInteract;
    
    public bool canInteract;
    public ETypeOfInteract typeOfInteract;
    public PlayerControl player;

    /// <summary>
    /// Whatever happens when interacting with the objects should happen here.
    /// </summary>
    public virtual void OnInteract()
    {
        
    }

    public void CallNotify(ETypeOfInteract _typeOfInteract, bool _onOff, PlayerControl _player)
    {
        OnNotifyInteract?.Invoke(_typeOfInteract, _onOff, _player);
    }

    /// <summary>
    /// What to update the UI with when enabling the pop-up. Must implement.
    /// </summary>
    public abstract void EnablePopUp();
    /// <summary>
    /// What to update the UI with when disabling the pop-up. Must implement.
    /// </summary>
    public abstract void DisablePopUp();

    private void OnEnable()
    {
        PlayerControl.OnActivate += PlayerControl_OnActivate;
    }

    private void OnDisable()
    {
        PlayerControl.OnActivate -= PlayerControl_OnActivate;
    }

    public virtual void PlayerControl_OnActivate(PlayerControl _player)
    {
        player = _player;   
    }
}
