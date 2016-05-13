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

          GameManager.instance.player.spellbook.Add(name_input.text, code_input.text);
          GameManager.instance.player.RAM_function = name_input.text;
          GameManager.instance.player.spellbook.TryGetValue(name_input.text, out GameManager.instance.player.RAM_function);
          GameManager.instance.player.spellnames_current.Add(name_input.text);
     }

     void Update()
     {
          if (Input.GetKeyDown(KeyCode.L))
          {
             //  Debug.Log("Load current spell");
               name_input.text = GameManager.instance.player.RAM_function;
               code_input.text = GameManager.instance.player.RAM_code;
              // spell_name.text = GameManager.instance.player.spellnames_current[0];//GameManager.instance.player.RAM_function;
               //spell_code.text = GameManager.instance.player.RAM_code;
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
