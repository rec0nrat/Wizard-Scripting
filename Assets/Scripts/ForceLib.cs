using UnityEngine;
using System.Collections;

namespace ForceLib
{
     public static class ForceLib
     {




          public static void AddRelative(GameObject obj)
          {
               // Debug.Log("Relative force function reached");
               Rigidbody rb = obj.GetComponent<Rigidbody>();
               rb.AddRelativeForce(Vector3.forward * 50);
          }



     }
}
