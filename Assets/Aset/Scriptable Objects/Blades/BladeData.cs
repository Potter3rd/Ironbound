using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ScriptableObject for blades
//Scribtalbe object but lets you create like an object that you can use to store data for blades and then use that data in the game
[CreateAssetMenu(fileName = "NewBlade", menuName = "Items/Blade")]
public class BladeData : ScriptableObject
{
    //Data for blades
    public string bladeName;
    public Sprite bladeSprite;
    public float damage;
}
