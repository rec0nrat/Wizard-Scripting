using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

     public static GameManager instance;

     public Player player;

	void Awake () {

	     if(instance == null)
          {
               instance = this;
               player = new Player();
               gameObject.GetComponent<PlayerInfo>().Init();
          }
          else
          {
               Destroy(this);
          }
          DontDestroyOnLoad(this.gameObject);
	}
	
     void Update()
     {
          if (Input.GetKeyDown(KeyCode.S))
          {
               gameObject.GetComponent<PlayerInfo>().Save();
          }
     }
	
}
