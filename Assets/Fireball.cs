using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

     void OnCollisionEnter(Collision collision)
     {
          Debug.Log(collision.gameObject.name);
         
          if(collision.gameObject.tag == "enemy")
          {
               Destroy(collision.gameObject);
               
          }
          Destroy(this.gameObject);
     }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
