using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Stats")]
    private int _vitality;
    private int _strength;
    private int _intelligent;
    private int _speed;
    private int _armor;
    private int _luck;

    private int _characterLevel;
    private CharacterClass _characterClass;
    private int _experiencePoint;

    public List<Item> _equippedItems;
    public enum CharacterClass
    {
        Mage,
        Archer,
        Warrior,
    }


}
