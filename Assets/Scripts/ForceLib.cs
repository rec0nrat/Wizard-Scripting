using UnityEngine;
using System.Collections;

namespace ForceLib
{
     public class ForceLib : MonoBehaviour
     {
          public static ForceLib instance;

          void Awake()
          {

               if (instance == null)
               {
                    instance = this;
                   // player = new Player();
                   // gameObject.GetComponent<PlayerInfo>().Init();
               }
               else
               {
                    Destroy(this);
               }
               DontDestroyOnLoad(this.gameObject);
          }

       public void AddRelative(GameObject obj)
       {
               Rigidbody rb = obj.GetComponent<Rigidbody>();
               rb.AddRelativeForce(Vector3.forward * 50f, ForceMode.Force);
       }

     }
}
