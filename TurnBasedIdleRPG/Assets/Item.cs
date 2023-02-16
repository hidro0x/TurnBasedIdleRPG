using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item {
    public string ItemName { get; }
    public Character.CharacterClass ItemClass { get; }
    public ItemTypeEnum ItemType{ get; }
    public ItemRarityEnum ItemRarity{ get; }
    public int ItemShopValue{ get; }
    //private Sprite _itemIcon{ get; }

    [field: Header("Item Stats")] public int WeaponDamage{ get; }
    public int Strength{ get; }
    public int Vitality{ get; }
    public int Speed{ get; }
    public int Intelligence{ get; }
    public int Armor{ get; }
    public int Luck{ get; }
    
    
    public enum ItemTypeEnum
    {
        Weapon,
        Boots,
        Pants,
        Chest,
        Helmet,
        Ring,
    }

    public enum ItemRarityEnum
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Mythic,
    }

    public Item(string itemName, Character.CharacterClass itemClass, ItemTypeEnum itemType, ItemRarityEnum itemRarity, 
        int itemShopValue, bool isWeapon, int weaponDamage, int strength, int vitality, int speed, int intelligence, int armor, int luck)
    {
        ItemName = itemName;
        ItemClass = itemClass;
        ItemType = itemType;
        ItemRarity = itemRarity;
        ItemShopValue = itemShopValue;
        WeaponDamage = isWeapon ? weaponDamage: 0;
        //_itemIcon = itemIcon;
        Strength = strength;
        Vitality = vitality;
        Speed = speed;
        Intelligence = intelligence;
        Armor = armor;
        Luck = luck;
    }
}
