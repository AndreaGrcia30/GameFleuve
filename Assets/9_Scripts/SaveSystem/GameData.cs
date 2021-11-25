using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;
using System.Linq;

[Serializable]
public class GameData
{
  [SerializeField]
  float posX = 0;
  [SerializeField]
  float posY = 0;
  [SerializeField]
  int currentPlayerHealth = 100;
  [SerializeField]
  int playerLevel = 1;
  [SerializeField]
  string[] items;

  [SerializeField]
  List<LevelPosition> positions = new List<LevelPosition>();

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
  public Vector2 Position(string level){
  LevelPosition pos = positions.FirstOrDefault(p=> p.level == level);
  if(pos != null) return new Vector2(pos.posX, pos.posY);

  return new Vector2();
  }
  public void SetPosition(Vector2 position, string LevelName)
  {
    posX = position.x;
    posY = position.y;
    LevelPosition pos = positions.FirstOrDefault(p=> p.level == LevelName);
    if(pos == null){
      pos = new LevelPosition();
      pos.level = LevelName;
      positions.Add(pos);
    }
    pos.posX = position.x;
    pos.posY = position.y;
  }
}

[Serializable]
public class LevelPosition{
  public float posX;
  public float posY;
  public string level;
}