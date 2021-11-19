using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

[Serializable]
public class GameData
{
  [SerializeField]
  float posX = 0;
  [SerializeField]
  float posY = 0;
  [SerializeField]
  int currentPlayerHealth = 4;
  [SerializeField]
  int playerLevel = 1;
  [SerializeField]
  string[] items;

  public GameData(){}

  public GameData( int currentPlayerHealth, int playerLevel, string[] items, float posX, float posY)
  {
    this.currentPlayerHealth = currentPlayerHealth;
    this.playerLevel = playerLevel;
    this.items = items;
    this.posX = posX;
    this.posY = posY;
  }

  public int CurrentPlayerHealth{get => currentPlayerHealth; set => currentPlayerHealth = value;}
  public int PlayerLevel{get => playerLevel; set => playerLevel = value;}
  public string[] Items{get => items; set => items = value;}
  public Vector2 Position => new Vector2(posX, posY);
  public void SetPosition(Vector2 position)
  {
    posX = position.x;
    posY = position.y;
  }
}