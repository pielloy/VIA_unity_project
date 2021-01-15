 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AutoRoomGestion : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player")) {
            S_RoomGestionPlayer m_roomGestion;

            foreach (GameObject element in GameObject.FindGameObjectsWithTag("Player"))
            {
                m_roomGestion = element.GetComponent<S_RoomGestionPlayer>() as S_RoomGestionPlayer;
                if (m_roomGestion)
                {
                    m_roomGestion.AddRoom(this.gameObject);
                }
            }
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {

            S_RoomGestionPlayer m_roomGestion;

            foreach (GameObject element in GameObject.FindGameObjectsWithTag("Player"))
            {
                m_roomGestion = element.GetComponent<S_RoomGestionPlayer>() as S_RoomGestionPlayer;
                if (m_roomGestion)
                {
                    m_roomGestion.removeRoom(this.gameObject);
                }
            }
        }
    }
}
