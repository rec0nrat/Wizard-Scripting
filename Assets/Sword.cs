using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

     void OnTriggerEnter(Collider other)
     {
          if(other.gameObject.tag == "enemy")
          {
               // Destroy(other.gameObject);
               Debug.Log("bash the spider with my sword!");
          }

     }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
