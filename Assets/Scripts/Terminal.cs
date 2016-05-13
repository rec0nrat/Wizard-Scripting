using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Terminal : MonoBehaviour {

     public Text spell_name;
     public Text spell_code;
     public Canvas terminal_can;


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
               if (terminal_can.enabled)
               {
                    terminal_can.enabled = false;
               }
               else
               {
                    Debug.Log("Open Terminal");
                    terminal_can.enabled = true;

               }
          }
     }
}
