using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [ReadOnly] private Character _player, _enemy;
    public Image playerProfilePlace;
    public Image enemyProfilePlace;
    public TextMeshProUGUI playerStats;
    public TextMeshProUGUI enemyStats;
    

    public void StartBattle()
    {
        _enemy = new
        StartCoroutine(BattleStarted());
    }
    

    IEnumerator BattleStarted()
    {
        SetBattleUI();
        while (_player.health <= 0 || _enemy.health <= 0)
        {
            if (_enemy.Speed < _player.Speed)
            {
                _player.Attack(_enemy);
                yield return new WaitForSeconds(1f);
                _enemy.Attack(_player);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                _enemy.Attack(_enemy);
                yield return new WaitForSeconds(1f);
                _player.Attack(_player);
                yield return new WaitForSeconds(1f);
            }
            
        }
    }

    private void SetBattleUI()
    {
        playerProfilePlace.color = Color.green;
        enemyProfilePlace.color = Color.red;
        enemyStats.text = "Vitality <br><br>" + _enemy.Vitality + "Strength <br><br>" + _enemy.Strength +
                          "Intelligence <br><br>" + _enemy.Speed + "Speed <br><br>" + _enemy.Speed +
                          "Luck <br><br>" + _enemy.Luck;
        playerStats.text = "Vitality <br><br>" + _player.Vitality + "Strength <br><br>" + _player.Strength +
                          "Intelligence <br><br>" + _player.Speed + "Speed <br><br>" + _player.Speed +
                          "Luck <br><br>" + _player.Luck;

    }
    
}


