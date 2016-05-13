using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic; 

public class GauntletUIManager : MonoBehaviour 
{
    public Text activeSpellText; 
    public List<Text> spells;

    void UpdateRAMUI(string[] spellNames)
    {
        int count = 0;
       
        for (int index = 0;
            index < spells.Count;
            ++index, ++count)
        {
            spells[index].text = spellNames[index];
        }

        // TODO(barret): figure out how to add a new spell
    }

    public void SpellButtonPressed(int Index)
    {
        activeSpellText.text = "Spell: " + spells[Index].text;

        // TODO(barret): Switch player spell here
    }
}
