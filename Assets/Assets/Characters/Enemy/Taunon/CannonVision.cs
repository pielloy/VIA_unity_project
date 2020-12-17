using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonVision : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player")) { 
            Debug.Log("Player enter");
            Animator anim = gameObject.GetComponentInParent(typeof(Animator)) as Animator;

            anim.SetBool("isAttacking?", true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player")) { 
            Debug.Log("Player exit");
            Animator anim = gameObject.GetComponentInParent(typeof(Animator)) as Animator;

            anim.SetBool("isAttacking?", false);
        }
    } 
}
