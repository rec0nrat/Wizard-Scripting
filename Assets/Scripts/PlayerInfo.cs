using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class PlayerInfo : MonoBehaviour {

     public void Init()
     {
          if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
          {
               //Read levels from csv and fill out level info
              // GameManager.gameManager.GetComponent<bubblewrap.TextReader>().GetLevelInfo();
              // GameManager.gameManager.player.levels[0].unlocked = true;
               GameManager.instance.GetComponent<PlayerInfo>().Save();

          }
          else {
               Load();
          }
     }


     public void Save()
     {
          BinaryFormatter bf = new BinaryFormatter();
          //if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat")) File.Create(Application.persistentDataPath + "/playerInfo.dat");
          //"/data/data/com.mycompany.myapp/files"
          FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
          //FileStream file = File.Create("" + Application.dataPath +"/playerInfo.dat");
         // GameManager.instance.player.oldDate = System.DateTime.Now;
          bf.Serialize(file, GameManager.instance.player);
          file.Close();
     }

     // Update is called once per frame
     public void Load()
     {
          if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
          {
               BinaryFormatter bf = new BinaryFormatter();
               FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

               GameManager.instance.player = (Player)bf.Deserialize(file);
              // GameManager.instance.player.Init();


               file.Close();
          }

          //GameManager.instance.player.currentDate = System.DateTime.Now;
          //if (GameManager.gameManager.player.oldDate.Day != GameManager.gameManager.player.currentDate.Day && GameManager.gameManager.player.oldDate.Month != GameManager.gameManager.player.currentDate.Month) GameManager.gameManager.player.showDailyPopup = true;
          GameManager.instance.GetComponent<PlayerInfo>().Save();
          //else
          //  {
          //    FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
          // }
     }
}

[Serializable]
public class Player
{
    
     public Dictionary<string,string> spellbook;
     public string[] libraries;
     public Dictionary<string, GameObject> castable_objects;
     public string name;
     public float RAM_MAX;
     public float RAM;
     public float health_MAX;
     public float health;
     public Dictionary<string, string> cached_spell;
     public float cache_delay;
     public float attack_power;

     public Player()
     {
         // Debug.Log("create player object");
     }
}
