using UnityEngine;
using System.Collections;

public class InteractItem : InteractBase
{       
    public delegate void FNotifyHiddenUI(bool _isHidden, bool playerIsIn);
    public static event FNotifyHiddenUI OnHide;
    
    // Collider del objeto
    
    Collider2D detectCollider;
    bool isHidden;
    bool playerInBounds;

    private void Start()
    {        
        detectCollider = GetComponentInChildren<Collider2D>();
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
        CallNotify(typeOfInteract, true, player);
        print("prender el boton");
    }

    /// <summary>
    /// Funcion que oculta y actualiza la UI como la anterior.
    /// </summary>
    public override void DisablePopUp()
    {
        canInteract = false;
        CallNotify(typeOfInteract, false, player);
        print("apagar el boton");
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
