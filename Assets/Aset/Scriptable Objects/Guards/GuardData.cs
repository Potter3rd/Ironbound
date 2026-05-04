using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBlade", menuName = "Items/Guard")]
public class GuardData : ScriptableObject
{
    public string guardName;
    public Sprite guardSprite;
    public float defense;
}
