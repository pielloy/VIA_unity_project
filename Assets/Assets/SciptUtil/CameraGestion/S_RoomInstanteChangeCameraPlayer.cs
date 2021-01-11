using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RoomInstanteChangeCameraPlayer : MonoBehaviour
{
    public Vector3 m_rotations;
    public float m_scale;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player")) {
            coll.transform.transform.rotation = Quaternion.Euler(m_rotations);
            coll.transform.Find("SpringArm").transform.localScale = new Vector3(m_scale, m_scale, m_scale);
        }
    }
}
