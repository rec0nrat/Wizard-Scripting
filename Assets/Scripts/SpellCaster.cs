using UnityEngine;
using System.Collections;
using System.IO;
using ForceLib;

using NLua;

public class SpellCaster : MonoBehaviour {

     public string source;
     public GameObject terminal;

     Lua env;

     public GameObject sphere;
     public Transform casting_point;
     public Transform righthand_slot;
     public GameObject weapon_obj;
     public GameObject spawnedObj;
     public GameObject sword;
     public Animator hand_anim;

     void Start()
     {
          
          string line;

          //Testing to see if I can load from a file in the resources folder
          TextAsset textFile = Resources.Load("Test") as TextAsset;
      
          line = textFile.text;
          
          // source = @line;

          source = GameManager.instance.player.RAM_code;

          env = new Lua();
          env.LoadCLRPackage();

          env["this"] = this;
          env["casting_point"] = casting_point;
          env["righthand_slot"] = righthand_slot;
          env["sphere"] = sphere; // Give the script access to the prefab.
          env["sword"] = sword;
          env["hand_anim"] = hand_anim;
          env["weapon_obj"] = weapon_obj;

         // env["obj"] = spawnedObj;
         // env["rb"] = this.gameObject.GetComponent<Rigidbody>();
        //  env["forward"] = new Vector3(0,0,1);

          //System.Object[] result = new System.Object[0];
          try
          {
               //result = env.DoString(source);
               env.DoString(source);
          }
          catch (NLua.Exceptions.LuaException e)
          {
               Debug.LogError(FormatException(e), gameObject);
          }

     }

   

     void Update()
     {

          // ForceLib.ForceLib.AddRelative(this.gameObject);
          if (!terminal.activeInHierarchy)
          {
               source = GameManager.instance.player.RAM_code;
               try
               {
                    //result = env.DoString(source);
                    env.DoString(source);
               }
               catch (NLua.Exceptions.LuaException e)
               {
                    Debug.LogError(FormatException(e), gameObject);
               }
               Call(GameManager.instance.player.RAM_function);
          }

          if (Input.GetMouseButtonDown(1))
          {
               hand_anim.SetTrigger("slash");
          }
          Call("Update");
     }


     public System.Object[] Call(string function, params System.Object[] args)
     {
          System.Object[] result = new System.Object[0];
          if (env == null) return result;
          LuaFunction lf = env.GetFunction(function);
          if (lf == null) return result;
          try
          {
               // Note: calling a function that does not
               // exist does not throw an exception.
               if (args != null)
               {
                    result = lf.Call(args);
               }
               else {
                    result = lf.Call();
               }
          }
          catch (NLua.Exceptions.LuaException e)
          {
               Debug.LogError(FormatException(e), gameObject);
          }
          return result;
     }

     public System.Object[] Call(string function)
     {
          return Call(function, null);
     }

     public static string FormatException(NLua.Exceptions.LuaException e)
     {
          string source = (string.IsNullOrEmpty(e.Source)) ? "<no source>" : e.Source.Substring(0, e.Source.Length - 2);
          return string.Format("{0}\nLua (at {2})", e.Message, string.Empty, source);
     }
}
