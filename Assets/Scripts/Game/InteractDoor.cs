using UnityEngine;

public class InteractDoor : InteractBase
{
    // Collider del objeto    
    DialogueTrigger dialogueTrigger;
    Collider2D detectCollider;
    public string levelToLoadName;
    public string doorKeyName;
    bool playerInBounds;
    public bool bDoorNeedsKey;

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
            if (bDoorNeedsKey)
            {
                dialogueTrigger.Dialogue();

                for (int i = 0; i < player.playerInventory.itemsInInventory.Count; i++)
                {
                    if (player.playerInventory.itemsInInventory[i].itemName == doorKeyName)
                    {
                        player.playerInventory.DeleteFromInv(player.playerInventory.itemsInInventory[i]);
                        GameManager.Instance.LoadNextLevel(levelToLoadName);
                    }
                    else print("Player needs the " + doorKeyName + " key.");
                }
            }
            else
            {
                GameManager.Instance.LoadNextLevel(levelToLoadName);
                print("Door doesn't need a key, opening...");
            }
        }
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
