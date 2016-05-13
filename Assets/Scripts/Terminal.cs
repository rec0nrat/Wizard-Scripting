using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Terminal : MonoBehaviour {

     public Text spell_name;
     public Text spell_code;
     public GameObject terminal_obj;
     public Text RAM_txt;
     public List<Text> spellslot_txt;
     public Text health_txt;


	public void Compile()
     {
          GameManager.instance.player.spellbook.Add(spell_name.text, spell_code.text);
          GameManager.instance.player.RAM_function = spell_name.text;
          GameManager.instance.player.spellbook.TryGetValue(spell_name.text, out GameManager.instance.player.RAM_function);
     }

     void Update()
     {
          if (Input.GetKeyDown(KeyCode.L))
          {
               spell_name.text = GameManager.instance.player.RAM_function;
               spell_code.text = GameManager.instance.player.RAM_code;
          }

          if (Input.GetKeyDown(KeyCode.T))
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
