using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Events
    public delegate void FPlayerInteract(PlayerControl _player);
    public static event FPlayerInteract OnActivate;

    // Bool
    public bool bUse;

    private float h;
    public float moveSpeedMultiplier = 5f;

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        PlayerInput();
    }

    /// <summary>
    /// Interacts with objects with class InteractBase and triggers event OnActivate
    /// </summary>
    public void UseObject()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bUse = true;
            OnActivate?.Invoke(this);
            Debug.Log("Player interacts");
        }
        else bUse = false;
    }

    /// <summary>
    /// Funcion que le permite moverse al jugador en el eje X.
    /// </summary>
    private void Movement()
    {
        //To know in which direction the player is facing, check if "h" is above or below 0. Above means right and below left.
        if (h > 0)
        {
            //lastDir = Vector3.right;
            //sr.flipX = false;
        }
        else if (h < 0)
        {
            //lastDir = Vector3.left;
            //sr.flipX = true;
        }

        //Apply movement speed
        h *= moveSpeedMultiplier * Time.fixedDeltaTime;
        //Move the fucker horizontally
        transform.Translate(h, 0f, 0f);
    }

    public void PlayerInput()
    {
        UseObject();
        h = Input.GetAxis("Horizontal");
    }
}
