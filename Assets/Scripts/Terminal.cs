using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Terminal : MonoBehaviour {

     public Text spell_name;
     public Text spell_code;

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
     }
}
