using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_tilePuzleColizion : MonoBehaviour
{
    public int m_x = 0;
    public int m_y = 0;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player")) {
            transform.parent.GetComponent<S_PuzzleFillTile>().switchTiles(m_y, m_x);
        }
    }
}
