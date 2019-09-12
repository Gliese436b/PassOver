using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameItem", menuName = "Elias/GameItem")]
public class GameItem : ScriptableObject
{
    public Sprite itemSprite;
    [TextArea(2, 6)]
    public string itemName;
    [TextArea(2, 10)]
    public string itemDescription;
}
