using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Terminal : MonoBehaviour {

    // public Text spell_name;
   //  public Text spell_code;
     public InputField name_input;
     public InputField code_input;
     public GameObject terminal_obj;
     public Text RAM_txt;
     public List<Text> spellslot_txt;
     public Text health_txt;

	public void Compile()
     {
          Debug.Log("compiling code");
          Spell stemp = new Spell(name_input.text, code_input.text);
          bool isDuplicate = false;
          //check if spell already exists
          for(int i = 0; i < GameManager.instance.player.spellbook.Count; i++)
          {
               if(GameManager.instance.player.spellbook[i].name == stemp.name)
               {
                    isDuplicate = true;
                    GameManager.instance.player.spellbook[i] = stemp;
                    GameManager.instance.player.RAM_code = stemp.code;
                    GameManager.instance.player.RAM_function = stemp.name;
                    break;
               }
          }

          if (!isDuplicate)
          {
               GameManager.instance.player.spellbook.Add(stemp);
               GameManager.instance.player.RAM_function = stemp.name;
               GameManager.instance.player.RAM_code = stemp.code;
              // GameManager.instance.player.spellnames_current.Add(name_input.text);
               Debug.Log("Dictionary new::cout = " + GameManager.instance.player.spellbook.Count);
          }
          /*
          if (GameManager.instance.player.spellbook.ContainsKey(name_input.text))
          {
               Debug.Log(code_input.text);
               GameManager.instance.player.spellbook[name_input.text] = new Dictionary<stri;
               
          }
          else
          {
               GameManager.instance.player.spellbook.Add(name_input.text, code_input.text);
               GameManager.instance.player.RAM_function = name_input.text;
               GameManager.instance.player.RAM_code = code_input.text;
               GameManager.instance.player.spellnames_current.Add(name_input.text);
               Debug.Log("Dictionary new::cout = " + GameManager.instance.player.spellbook.Count);
          }
          */
     }

     void Update()
     {
          if (Input.GetKeyDown(KeyCode.LeftControl))
          {
             //  Debug.Log("Load current spell");
               name_input.text = GameManager.instance.player.RAM_function;
               code_input.text = GameManager.instance.player.RAM_code;
              // spell_name.text = GameManager.instance.player.spellnames_current[0];//GameManager.instance.player.RAM_function;
               //spell_code.text = GameManager.instance.player.RAM_code;
          }

          if (Input.GetKeyDown(KeyCode.Tab))
          {
               if (terminal_obj.activeInHierarchy)
               {
                    terminal_obj.SetActive(false);
               }
               else
               {
                   // Debug.Log("Open Terminal");
                    terminal_obj.SetActive(true);

               }
          }
     }
}
