using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    /// <summary>
    /// Preloader needs to be on the very first scene, otherwise GameInstance won't work
    /// </summary>

    public GameInstance instance;
       
    private void Awake()
    {
        
    }
}
