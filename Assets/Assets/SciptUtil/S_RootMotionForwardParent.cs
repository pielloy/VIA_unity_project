using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RootMotionForwardParent : MonoBehaviour
{
    Animator m_anim;

    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    void OnAnimatorMove()
    { 
        transform.parent.transform.position = m_anim.rootPosition;
    }
}
