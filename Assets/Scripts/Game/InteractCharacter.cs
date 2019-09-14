using UnityEngine;

public class InteractCharacter : InteractBase
{
    // Collider del objeto

    DialogueTrigger dialogueTrigger;
    Collider2D detectCollider;
    bool playerInBounds;

    private void Awake()
    {
        detectCollider = GetComponentInChildren<Collider2D>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    /// <summary>
    /// Funcion que se llama cuando el evento PlayerController.OnActivate se dispara
    /// </summary>
    public override void OnInteract()
    {
        playerInBounds = detectCollider.bounds.Contains(player.transform.position);

        if (playerInBounds)
        {
            dialogueTrigger.Dialogue();
            DisablePopUp();
        }
    }

    /// <summary>
    /// Implementacion del evento OnActivate del player.
    /// </summary>
    public override void PlayerControl_OnActivate(PlayerController _player)
    {
        //print("player" + _player);
        base.PlayerControl_OnActivate(_player);
        OnInteract();
        if (!canInteract) return;
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

