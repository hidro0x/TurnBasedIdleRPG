using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    
    public Character CreateCharacter(int vitality, int strength, int intelligent, int speed, int armor, float luck,
        Character.CharacterClass characterClass)
    {
        var character = gameObject.AddComponent<Character>();
        character.Vitality = vitality;
        character.Strength = strength;
        character.Intelligent = intelligent;
        character.Speed = speed;
        character.Armor = armor;
        character.Luck = luck;
        character.CharacterClassType = characterClass;
        return character;

    }
    
}
