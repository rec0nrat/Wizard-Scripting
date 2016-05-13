using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic; 

public class GauntletUIManager : MonoBehaviour 
{
    public Text activeSpellText; 
    public List<Text> spells;
	// Use this for initialization
	void Start () 
    {
        //spells = new List<Text>(); 
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void UpdateRAMUI(string[] spellNames)
    {
        
    }

    public void SpellButtonPressed(int Index)
    {
        activeSpellText.text = "Spell: " + spells[Index].text;

        // TODO(barret): Switch player spell here
    }
}
