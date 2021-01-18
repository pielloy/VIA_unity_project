using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class S_RoomGestionPlayer : MonoBehaviour
{
    public ArrayList m_Rooms = new ArrayList();
    private Volume m_postProcessing;
    private float m_value;
    public float m_speed = 0.01f;

    void Awake()
    {
        m_postProcessing = GameObject.FindGameObjectsWithTag("PostProcessing")[0].GetComponent<Volume>();
        enabled = false;
    }

    public void AddRoom(GameObject room)
    {
        m_Rooms.Add(room);
    }

    public void removeRoom(GameObject room)
    {
        m_Rooms.Remove(room);
        room.transform.Find("Content").transform.gameObject.SetActive(false);
        if (m_Rooms.Count == 1 && !((GameObject)m_Rooms[0]).transform.Find("Content").transform.gameObject.activeSelf) {
            ((GameObject)m_Rooms[0]).transform.Find("Content").transform.gameObject.SetActive(true);
            enabled = true;
            m_value = 1;
        }
    }

    void Update()
    {
        m_value -= m_speed;
        if (m_value <= 0) {
            enabled = false;
            m_value = 0;
        }
        m_postProcessing.weight = m_value;
    }
}
