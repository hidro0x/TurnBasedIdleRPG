using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField] private Character _player, _enemy;

    private void StartBattle()
    {
        while (_player.health <= 0 || _enemy.health <= 0)
        {
            StartCoroutine(BattleStarted());
            _player.Attack(_enemy);
            _enemy.Attack(_player);
        }
    }
    

    IEnumerator BattleStarted()
    {
        while (_player.health <= 0 || _enemy.health <= 0)
        {
            _player.Attack(_enemy);
            yield return new WaitForSeconds(1f);
            _enemy.Attack(_player);
            yield return new WaitForSeconds(1f);
        }
    }
}


