using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

[Serializable]
public class GameData
{
  [SerializeField]
  int currentPlayerHealth = 4;
  [SerializeField]
  int playerLevel = 1;
  [SerializeField]
  string[] items;

  public GameData(){}

  public GameData( int currentPlayerHealth, int playerLevel, string[] items)
  {
    this.currentPlayerHealth = currentPlayerHealth;
    this.playerLevel = playerLevel;
    this.items = items;
  }

  public int CurrentPlayerHealth => currentPlayerHealth;
  public int PlayerLevel => playerLevel;
  public string[] Items => items;
}