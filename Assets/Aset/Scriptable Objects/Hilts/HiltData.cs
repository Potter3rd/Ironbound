using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHilt", menuName = "Items/Hilt")]
public class HiltData : ScriptableObject
{
    public string hiltName;
    public Sprite hiltSprite;
    public float health;
}
