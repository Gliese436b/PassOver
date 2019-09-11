using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Events
    public delegate void FPlayerInteract(PlayerControl _player);
    public static event FPlayerInteract OnActivate;

    public delegate void FPlayerEnable(PlayerControl _player);
    public static event FPlayerEnable OnPlaying;

    // Bool
    public bool bCanPlay;
    public bool bUse;

    // Numbers
    private float h;
    public float moveSpeedMultiplier = 5f;

    // Components
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Initialize();
    }    

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        PlayerInput();
    }

    /// <summary>
    /// Used to set-up the player at the start of the game.
    /// </summary>
    private void Initialize()
    {
        bCanPlay = true;
        OnPlaying?.Invoke(this);
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
        if (!bCanPlay) return;

        Vector3 lastDir;
        //To know in which direction the player is facing, check if "h" is above or below 0. Above means right and below left.
        if (h < 0)
        {
            lastDir = Vector3.right;
            sr.flipX = false;
        }
        else if (h > 0)
        {
            lastDir = Vector3.left;
            sr.flipX = true;
        }

        //Apply movement speed
        h *= moveSpeedMultiplier * Time.fixedDeltaTime;
        //Move the fucker horizontally
        transform.Translate(h, 0f, 0f);
    }

    public void PlayerInput()
    {
        if (!bCanPlay) return;

        UseObject();
        h = Input.GetAxis("Horizontal");
    }
}
