using UnityEngine;
using System.Collections;

public class AnimationTrigger : MonoBehaviour 
{
    public Animation clip;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            clip.Play("DoorClose");
        }
    }
}
