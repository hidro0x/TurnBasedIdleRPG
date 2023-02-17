using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Battle : MonoBehaviour
{
    [ReadOnly] private Character _player, _enemy;
    public Image playerProfilePlace;
    public Image enemyProfilePlace;
    public TextMeshProUGUI playerStats;
    public TextMeshProUGUI enemyStats;
    

    public void StartBattle()
    {
        _player = GameManager.instance.Player;
        _enemy = CreateEnemy(4, Character.CharacterClass.Mage);
        Debug.Log(_enemy.health);
        Debug.Log(_player.health);
        StartCoroutine(BattleStarted());
    }


    private IEnumerator BattleStarted()
    {

        SetBattleUI();
        while (_player.health >= 0 || _enemy.health >= 0)
        {
            if (_enemy.Speed < _player.Speed)
            {
                _player.Attack(_enemy);
                yield return new WaitForSeconds(2f);
                _enemy.Attack(_player);
                yield return new WaitForSeconds(2f);
            }
            else
            {
                _enemy.Attack(_enemy);
                yield return new WaitForSeconds(2f);
                _player.Attack(_player);
                yield return new WaitForSeconds(2f);
            }

            if (_player.health <= 0)
            {
                Debug.Log("Düşman kazandı");
                break;
            }
            if (_enemy.health <= 0)
            {
                Debug.Log("Player kazandı.");
                break;
            }
            
        }
    }

    private void SetBattleUI()
    {
        playerProfilePlace.color = Color.green;
        enemyProfilePlace.color = Color.red;
        enemyStats.text = "Vitality" + _enemy.Vitality + "<br>Strength " + _enemy.Strength +
                          "<br>Intelligence" + _enemy.Speed + "<br>Speed " + _enemy.Speed +
                          "<br>Luck " + _enemy.Luck;
        playerStats.text = "Vitality " + _player.Vitality + "<br>Strength " + _player.Strength +
                          "<br>Intelligence " + _player.Speed + "<br>Speed " + _player.Speed +
                          "<br>Luck " + _player.Luck;

    }

    public Character CreateEnemy(int enemyLevel, Character.CharacterClass characterClass)
    {
        var enemy = new Character();
        enemy.CharacterLevel = enemyLevel;
        switch (characterClass)
        {
            case Character.CharacterClass.Warrior:
                enemy.Strength = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 4 - enemy.CharacterLevel * 4 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 4 + enemy.CharacterLevel * 4 / 100 * 15));
                enemy.Vitality = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 5 - enemy.CharacterLevel * 5 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 5 + enemy.CharacterLevel * 5 / 100 * 15));
                enemy.Intelligent = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 - enemy.CharacterLevel * 2 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 + enemy.CharacterLevel * 2 / 100 * 15));
                enemy.Speed = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 - enemy.CharacterLevel * 2 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 + enemy.CharacterLevel * 2 / 100 * 15));
                enemy.Luck = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 - enemy.CharacterLevel * 2 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 + enemy.CharacterLevel * 2 / 100 * 15));
                enemy.Armor = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 3 - enemy.CharacterLevel * 3 / 100 * 15),
                    Mathf.RoundToInt(enemy.CharacterLevel * 3 + enemy.CharacterLevel * 3 / 100 * 15));
                break;
            case Character.CharacterClass.Mage:
                enemy.Strength = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 - enemy.CharacterLevel * 2 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 + enemy.CharacterLevel * 2 / 100 * 15));
                enemy.Vitality = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 3 - enemy.CharacterLevel * 3 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 3 + enemy.CharacterLevel * 3 / 100 * 15));
                enemy.Intelligent = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 5 - enemy.CharacterLevel * 5 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 5 + enemy.CharacterLevel * 5 / 100 * 15));
                enemy.Speed = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 - enemy.CharacterLevel * 2 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 + enemy.CharacterLevel * 2 / 100 * 15));
                enemy.Luck = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 - enemy.CharacterLevel * 2 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 + enemy.CharacterLevel * 2 / 100 * 15));
                enemy.Armor = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 - enemy.CharacterLevel * 2 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 + enemy.CharacterLevel * 2 / 100 * 15));
                break;
            case Character.CharacterClass.Archer:
                enemy.Strength = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 - enemy.CharacterLevel * 2 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 + enemy.CharacterLevel * 2 / 100 * 15));
                enemy.Vitality = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 4 - enemy.CharacterLevel * 4 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 4 + enemy.CharacterLevel * 4 / 100 * 15));
                enemy.Intelligent = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 - enemy.CharacterLevel * 2 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 2 + enemy.CharacterLevel * 2 / 100 * 15));
                enemy.Speed = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 4 - enemy.CharacterLevel * 4 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 4 + enemy.CharacterLevel * 4 / 100 * 15));
                enemy.Luck = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 3 - enemy.CharacterLevel * 3 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 3 + enemy.CharacterLevel * 3 / 100 * 15));
                enemy.Armor = Random.Range(
                    Mathf.RoundToInt(enemy.CharacterLevel * 3 - enemy.CharacterLevel * 3 / 100 * 15), 
                    Mathf.RoundToInt(enemy.CharacterLevel * 3 + enemy.CharacterLevel * 3 / 100 * 15));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(characterClass), characterClass, null);
        }
        enemy.GiveBasicItems();
        enemy.SetDamageAndHealth();
        return enemy;
    }
    
    
}


