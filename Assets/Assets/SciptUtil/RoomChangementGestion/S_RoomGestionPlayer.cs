using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class S_RoomGestionPlayer : MonoBehaviour
{
    public ArrayList m_Rooms = new ArrayList();
    private ColorAdjustments m_CALayer;

    void Awake()
    {
        Volume m_postProcessing;

        foreach (GameObject element in GameObject.FindGameObjectsWithTag("PostProcessing"))
        {
            
        }
    }

    public void AddRoom(GameObject room)
    {
        m_Rooms.Add(room);
    }

    public void removeRoom(GameObject room)
    {
        m_Rooms.Remove(room);
        room.transform.Find("Content").transform.gameObject.SetActive(false);
        if (m_Rooms.Count == 1)
            ((GameObject)m_Rooms[0]).transform.Find("Content").transform.gameObject.SetActive(true);
    }

    void FixedUpdate()
    {
        
    }
}
