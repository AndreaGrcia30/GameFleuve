using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;
using System.IO;

namespace GameLib.MemorySystem
{
  public class MemorySystem
  {
    public static void NewGame(string gameName)
    {
      string savePath = GetFilePath(gameName);
      GameData gameData = new GameData();
      string json = SaveToString(gameData);
      File.WriteAllText(savePath, json);
      GameManager.instance.CurrentGameData = gameData;
    }

    public static void LoadGame(string gameName)
    {
      string savePath = GetFilePath(gameName);
      if(FileExist(savePath))
      {
        string json = GetJsonFromFile(savePath);

        GameManager.instance.CurrentGameData = GetGameDataFromJson(json);
        GameManager.instance.GetGameFoundation.Clear();
        foreach(string itemDefiniton in GameManager.instance.CurrentGameData.Items)
        {
          InventoryItemDefinition definition = GameManager.instance.GetGameFoundation.GetItem(itemDefiniton);
          InventoryItem item = GameManager.instance.GetGameFoundation.CreateItem(definition);
          GameManager.instance.GetGameFoundation.AddItemToInventory(item);
          GameManager.instance.GetGameFoundation.AddItemDefinitionKeyToInventory(itemDefiniton);
        }
      }
    }

    public static void SaveGame(GameData gameData, string gameName)
    {
      string savePath = GetFilePath(gameName);
      if(FileExist(savePath))
      {
        GameManager.instance.CurrentGameData = gameData;
        string json = SaveToString(gameData);
        File.WriteAllText(savePath, json);
      }
    }
    //string GetFilePath(string fileName) => Application.persistentDataPath + "/" + fileName + ".json";
    static string GetFilePath(string fileName) => Path.Combine(Application.persistentDataPath, fileName + ".json");
    static bool FileExist(string filePath) => File.Exists(filePath);

    static string SaveToString(GameData gameData) => JsonUtility.ToJson(gameData);
    static string GetJsonFromFile(string filePath) => File.ReadAllText(filePath);
    static GameData GetGameDataFromJson(string json) => JsonUtility.FromJson<GameData>(json);
  }
}