using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour 
{

    public void ResetGame()
    {
        Application.LoadLevel(0);
    }
}
