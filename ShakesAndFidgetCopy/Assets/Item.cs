using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Create Item")]
public class Item : ScriptableObject{

    public string itemName;
    public Player.CharacterClass itemClass;
    public ItemType itemType;
    public ItemRarity itemRarity;
    public int itemShopValue;
    
    [Header("Item Stats")]
    public int strength;
    public int vitality;
    public int speed;
    public int intelligence;
    public int armor;
    public int luck;
    
    
    public enum ItemType
    {
        Weapon,
        Boots,
        Pants,
        Chest,
        Helmet,
        Ring,
    }

    public enum ItemRarity
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Mythic,
    }
}
