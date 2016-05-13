﻿using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class PlayerInfo : MonoBehaviour
{

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
public class Spell
{
     public string name;
     public string code;

     public Spell() { }

     public Spell(string sname, string scode)
     {
          name = sname;
          code = scode;
     }
}

[Serializable]
public class Player
{
    
     public List<Spell> spellbook;
     public string[] libraries;
    // public List<string> spellnames_current;
     public Dictionary<string, GameObject> castable_objects;
     public string name;
     public float memory_MAX;
     public float memory;
     public float health_MAX;
     public float health;
     public string RAM_code;
     public string RAM_function;
     public float RAM_delay;
     public float attack_power;

     public Player()
     {
          //spellnames_current = new List<string>();

          //spellbook = new Dictionary<string, string>();
          spellbook = new List<Spell>();

          Spell newSpell = new Spell("Fireball", @"
import 'System'
import 'UnityEngine'
import 'Assembly-CSharp'-- The user - code assembly generated by Unity
import 'ForceLib'

--righthand_slot = transform for hand
--casting_point = transform for spell instantiation point

function Fireball()
     local obj
     if Input.GetMouseButtonDown(0) then

          obj = GameObject.Instantiate(sphere, casting_point.position, this.transform.rotation)
          ForceLib.AddRelative(obj)
          --obj:GetComponent('Rigidbody'):AddRelativeForce(Vector3.forward * 50)

     end
end

");
          spellbook.Add(newSpell);
          RAM_function = spellbook[0].name;
         RAM_code = spellbook[0].code;
          
     }
}
