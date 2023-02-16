using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
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
    
    public enum CharacterClass
    {
        Mage,
        Archer,
        Warrior,
    }

    [Header("Values")] public int attackDamage, health;

    
    private void Start()
    {
        if (EquippedItems == null) return;
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
        }

    }
    
    public void Attack(Character enemy)
    {
        var chanceToCritical = Luck * 0.1f;
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
    }
}
