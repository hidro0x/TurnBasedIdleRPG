using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Image classImagePlace;
    public Sprite[] classImages;
    public string[] classDescriptions;
        
    public void CreateWarrior()
    {
        GameManager.instance.Player = new Character(15, 18, 9, 13, 0, 10, Character.CharacterClass.Warrior, 
            1, 0, null);
        classImagePlace.sprite = classImages[0];

    }
    
    public void CreateMage()
    {
        GameManager.instance.Player = new Character(11, 8, 18, 12, 0, 16, Character.CharacterClass.Warrior, 
            1, 0, null);
        classImagePlace.sprite = classImages[1];
    }
    
    public void CreateArcher()
    {
        GameManager.instance.Player = new Character(14, 12, 10, 17, 0, 12, Character.CharacterClass.Warrior, 
            1, 0, null);
        classImagePlace.sprite = classImages[2];
    }

    public void StartGame()
    {
        if (GameManager.instance.Player != null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Karakter seçimi yapılmadı.");
        }
    }
    
}
