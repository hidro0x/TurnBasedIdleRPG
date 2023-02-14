using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{

    public string itemName;
    public Character.CharacterClass itemClass;
    public ItemType itemType;
    public ItemStats itemStats;
    public ItemRarity itemRarity;
    public int itemShopValue;
    
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
    
    public struct ItemStats
    {
        public int Strength;
        public int Vitality;
        public int Speed;
        public int Intelligence;
        public int Armor;
        public int Luck;

    }
}
