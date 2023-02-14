using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    [Header("Stats")]
    private int _vitality;
    private int _strength;
    private int _intelligent;
    private int _speed;
    private int _armor;
    private float _luck;
    private CharacterClass _characterClass;
    
    public enum CharacterClass
    {
        Mage,
        Archer,
        Warrior,
    }

    [Header("Values")] public int attackDamage, health;

    private void Start()
    {
        switch (_characterClass)
        {
            case CharacterClass.Mage:
                attackDamage = _intelligent * 5;
                health = _vitality * 2;
                break;
            case CharacterClass.Archer:
                attackDamage = _speed * 4;
                health = _vitality * 3;
                break;
            case CharacterClass.Warrior:
                attackDamage = _strength * 3;
                health = _vitality * 4;
                break;
        }
    }


    public void Attack(Character enemy)
    {
        var chanceToCritical = _luck * 0.1f;
        var makeCriticalStrike = Random.Range(0f, 100f) < chanceToCritical;
        if (makeCriticalStrike)
        {
            var dealDamage = Random.Range((attackDamage - attackDamage / 10) * 2, (attackDamage + attackDamage / 10) * 2);
            enemy.health -= Mathf.RoundToInt(dealDamage - dealDamage / 100 * enemy._armor * 0.05f);
        }
        else
        {
            var dealDamage = Random.Range(attackDamage - attackDamage / 10, attackDamage + attackDamage / 10);
            enemy.health -= Mathf.RoundToInt(dealDamage - dealDamage / 100 * enemy._armor * 0.05f);
        }

        


    }


}
