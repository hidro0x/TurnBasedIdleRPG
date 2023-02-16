using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private CharacterSelection characterSelection;

    public Character Player { get; set; }
    private bool _isNewPlayer;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (_isNewPlayer && Player == null)
        {
            characterSelection.gameObject.SetActive(true);
        }
    }
}
