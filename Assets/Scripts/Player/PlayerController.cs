﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Events
    public delegate void FPlayerInteract(PlayerController _player);
    public static event FPlayerInteract OnActivate;

    public delegate void FPlayerEnable(PlayerController _player);
    public static event FPlayerEnable OnPlaying;

    // Bool
    public bool bCanPlay;
    public bool bUse;
    public bool bUseInventory;

    // Numbers
    private float h;
    public float moveSpeedMultiplier = 5f;

    // Components
    private SpriteRenderer sr;
    public ItemInventory playerInventory;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        DialogueManager.OnFinishTalk += DialogueManager_OnFinishTalk;
        DialogueManager.OnTalk += DialogueManager_OnTalk;
    }

    private void OnDisable()
    {
        DialogueManager.OnFinishTalk -= DialogueManager_OnFinishTalk;
        DialogueManager.OnTalk -= DialogueManager_OnTalk;
    }

    private void DialogueManager_OnTalk()
    {
        bCanPlay = false;
        print("Began interaction, can't move");
    }

    private void DialogueManager_OnFinishTalk()
    {
        bCanPlay = true;
        print("Stopped interaction, can move");
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
        //PrintInput();
    }

    void PrintInput()
    {
        Debug.Log(h);
        Debug.Log(bUse);
    }

    /// <summary>
    /// Used to set-up the player at the start of the game.
    /// </summary>
    private void Initialize()
    {
        bCanPlay = true;
        OnPlaying?.Invoke(this);
    }

    public void PlayerInput()
    {
        if (!bCanPlay) return;
        UseObject();
        UseInventory();
        h = Input.GetAxis("Horizontal");
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
            //Debug.Log("Player press E");
        }
        else bUse = false;
    }

    /// <summary>
    /// Changes bOpenInventory to true for listening objects like InventoryUI to respond to.
    /// </summary>
    public void UseInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bUseInventory = true;
            OnActivate?.Invoke(this);
            Debug.Log("Player opens inventory");
        }
        else bUseInventory = false;
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

}
