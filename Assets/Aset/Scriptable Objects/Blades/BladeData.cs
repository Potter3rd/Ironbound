using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBlade", menuName = "Items/Blade")]
public class BladeData : ScriptableObject
{
    public string bladeName;
    public Sprite bladeSprite;
    public float damage;
}
