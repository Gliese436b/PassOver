using UnityEngine;
using System.Collections;

public class ShadowHide:InteractBase
{       
    public delegate void FNotifyHiddenUI(bool _isHidden, bool playerIsIn);
    public static event FNotifyHiddenUI OnHide;
    
    // Collider del objeto
    Collider detectCollider;
    public string leaveShadowText = "EXIT SHADOWS.";
    bool isHidden;
    bool playerInBounds;

    private void Start()
    {        
        detectCollider = GetComponentInChildren<Collider>();
    }

    /// <summary>
    /// Funcion que se llama cuando el evento PlayerController.OnActivate se dispara
    /// </summary>
    public override void OnInteract()
    {        
        playerInBounds = detectCollider.bounds.Contains(player.transform.position);
        OnHide?.Invoke(isHidden, playerInBounds);
    }

    /// <summary>
    /// Implementacion del evento OnActivate del player.
    /// </summary>
    public override void PlayerControl_OnActivate(PlayerControl _player)
    {
        base.PlayerControl_OnActivate(_player);
        if (!canInteract) return;
        OnInteract();
    }
    
    /// <summary>
    /// Funcion que muestra y actualiza la UI con la informacion pertinente al objeto.
    /// </summary>
    public override void EnablePopUp()
    { 
        canInteract = true;
        CallNotify(ETypeOfInteract.ITEM, true, player);
    }

    /// <summary>
    /// Funcion que oculta y actualiza la UI como la anterior.
    /// </summary>
    public override void DisablePopUp()
    {
        canInteract = false;
        CallNotify(ETypeOfInteract.ITEM, false, player);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            EnablePopUp();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            DisablePopUp();
        }
    }
}
