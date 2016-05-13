using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic; 

public class GauntletUIManager : MonoBehaviour 
{
    public Text activeSpellText; 
    public List<Text> spells;
     /*
    void UpdateRAMUI(string[] spellNames)
    {
        int count = 0;
       
        for (int index = 0;
            index < GameManager.instance.player.spellbook.Count;
            ++index, ++count)
        {
            spells[index].text = spellNames[index];
        }

        // TODO(barret): figure out how to add a new spell
    }*/

    public void SpellButtonPressed(int Index)
    {
          int count = GameManager.instance.player.spellbook.Count;
          if (Index >= 0 && Index < count)
          {
               activeSpellText.text = spells[Index].text;
               GameManager.instance.player.RAM_code = GameManager.instance.player.spellbook[Index].code;
               GameManager.instance.player.RAM_function = GameManager.instance.player.spellbook[Index].name;

          }

        // TODO(barret): Switch player spell here
    }

    
}
