using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class HealthUIManager : MonoBehaviour 
{
    public Text healthText;

    public void UpdateHealth(float amount)
    {
        healthText.text = "Health:  " + amount;

        if (amount <= 0)
        {
            healthText.text = "Dead Player";
        }
    }
}
