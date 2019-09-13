using UnityEngine;
using System.Collections;

public class InteractItem : InteractBase
{       
    // Collider del objeto
    
    Collider2D detectCollider;
    public GameItem item;
    SpriteRenderer sr;
    bool playerInBounds;

    private void Awake()
    {
        detectCollider = GetComponentInChildren<Collider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {  
        sr.sprite = item.itemSprite;
    }

    /// <summary>
    /// Funcion que se llama cuando el evento PlayerController.OnActivate se dispara
    /// </summary>
    public override void OnInteract()
    {        
        playerInBounds = detectCollider.bounds.Contains(player.transform.position);
        player.playerInventory.itemsInInventory.Add(item);
        gameObject.SetActive(false);
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
    }

    /// <summary>
    /// Funcion que oculta y actualiza la UI como la anterior.
    /// </summary>
    public override void DisablePopUp()
    {
        canInteract = false;
        CallNotify(typeOfInteract, false, player);
        
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
