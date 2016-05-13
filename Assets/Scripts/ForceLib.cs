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
               rb.AddRelativeForce(Vector3.forward * 800f);
          }

          public static void AttachObject(GameObject obj, GameObject objParent)
          {
               obj.transform.parent = objParent.transform;
          }

          public static void Slash(Animator anim)
          {
               anim.SetTrigger("slash");
          }

     }
}
