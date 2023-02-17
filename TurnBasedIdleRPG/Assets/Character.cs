using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character
{
    public int Vitality{ get; set; }
    public int Strength{ get; set; }
    public int Intelligent{ get; set; }
    public int Speed{ get; set; }
    public int Armor { get; set; }
    public float Luck { get; set; }
    public CharacterClass CharacterClassType { get; set; }
    
    public int CharacterLevel { get; set; }
    
    public int ExperiencePoint { get; set; }
    
    public List<Item> EquippedItems { get; set; }
    
    public bool IsPlayer { get; set; }
    
    public enum CharacterClass
    {
        Mage,
        Archer,
        Warrior,
    }

    [Header("Values")] public int attackDamage, health;

    public Character()
    {
        
    }

    public Character(int vitality, int strength, int intelligent, int speed, int armor, int luck, 
        CharacterClass classType, int characterLevel, int experiencePoint, List<Item> equippedItems, bool isPlayer)
    {
        Vitality = vitality;
        Strength = strength;
        Intelligent = intelligent;
        Speed = speed;
        Armor = armor;
        Luck = luck;
        CharacterClassType = classType;
        CharacterLevel = characterLevel;
        ExperiencePoint = experiencePoint;
        EquippedItems = equippedItems;
        IsPlayer = isPlayer;
        GiveBasicItems();
        SetDamageAndHealth();
        
    }

    
    
    public void Attack(Character enemy)
    {
        var chanceToCritical = Luck * 5 / (enemy.CharacterLevel * 2);
        if (chanceToCritical > 50f) chanceToCritical = 50f;
        var makeCriticalStrike = Random.Range(0f, 100f) < chanceToCritical;
        if (makeCriticalStrike)
        {
            var dealDamage = Random.Range((attackDamage - attackDamage / 10) * 2, (attackDamage + attackDamage / 10) * 2);
            enemy.health -= Mathf.RoundToInt(dealDamage - dealDamage / 100 * enemy.Armor * 0.05f);
        }
        else
        {
            var dealDamage = Random.Range(attackDamage - attackDamage / 10, attackDamage + attackDamage / 10);
            enemy.health -= Mathf.RoundToInt(dealDamage - dealDamage / 100 * enemy.Armor * 0.05f);
        }
        Debug.Log("Saldıran " + IsPlayer + " Saldırdığı " + enemy + " karşı taraf kalan can " + enemy.health + " kritik şansı " + chanceToCritical + " kritik vuruldu mu " + makeCriticalStrike);
    }

    public void SetDamageAndHealth()
    {
        var equippedWeapon = EquippedItems.Find(x => x.ItemType == Item.ItemTypeEnum.Weapon);
        switch (CharacterClassType)
        {
            case CharacterClass.Mage:
                attackDamage = equippedWeapon.WeaponDamage * 4 * Mathf.RoundToInt(1 + Intelligent / 10);
                health = Vitality * 2 * (CharacterLevel + 1);
                break;
            case CharacterClass.Archer:
                attackDamage = equippedWeapon.WeaponDamage * 4 * Mathf.RoundToInt(1 + Speed / 10);
                health = Vitality * 4 * (CharacterLevel + 1);
                break;
            case CharacterClass.Warrior:
                attackDamage = equippedWeapon.WeaponDamage * 4 * Mathf.RoundToInt(1 + Strength / 10);
                health = Vitality * 5 * (CharacterLevel + 1);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void GiveBasicItems()
    {
        EquippedItems ??= new List<Item>();
        switch (CharacterClassType)
        {
            case CharacterClass.Mage:
                EquippedItems.Add(new Item("Basic Warrior Item", CharacterClass.Warrior, Item.ItemTypeEnum.Weapon,
                    Item.ItemRarityEnum.Common, 0, true, 5, 2, 2 , 0, 0,
                    0, 0));
                break;
            case CharacterClass.Archer:
                EquippedItems.Add(new Item("Basic Archer Item", CharacterClass.Archer, Item.ItemTypeEnum.Weapon,
                    Item.ItemRarityEnum.Common, 0, true, 5, 0, 2 , 2, 0,
                    0, 0));
                break;
            case CharacterClass.Warrior:
                EquippedItems.Add(new Item("Basic Warrior Item", CharacterClass.Warrior, Item.ItemTypeEnum.Weapon,
                    Item.ItemRarityEnum.Common, 0, true, 5, 2, 2 , 0, 0,
                    0, 0));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
