using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class t_tile
{
    public t_tile(GameObject obj)
    {
        m_obj = obj;
        m_active = true;
    }

    public GameObject m_obj;
    public bool m_active;
}

public class S_PuzzleFillTile : MonoBehaviour
{
    private t_tile[ , ] m_tiles = new t_tile[3 , 3];
    private int m_numbTillesActive;
    public GameObject door;
    bool isActive = false;

    // Start is called before the first frame update
    void Awake()
    {
        for (int j = 0; j != 3; j++) {
            for (int i = 0; i != 3; i++)
                m_tiles[j, i] = new t_tile(transform.Find("fillTiles_" + j + "_" + i).gameObject);
        }
        m_numbTillesActive = 9;
        switchTiles(2, 2);
        switchTiles(1, 2);
    }

    private void switchTile(int y, int x)
    {
        if (m_tiles[y, x].m_active) {
            m_tiles[y, x].m_active = false;
            m_tiles[y, x].m_obj.GetComponent<Renderer>().material.SetFloat("Vector1_3066DC5E", 0);
            m_numbTillesActive--;
        } else {
            m_tiles[y, x].m_active = true;
            m_tiles[y, x].m_obj.GetComponent<Renderer>().material.SetFloat("Vector1_3066DC5E", 1);
            m_numbTillesActive++;
        }
    }

    public void switchTiles(int y, int x)
    {
        if (!isActive)
        {
            switchTile(y, x);
            if (x > 0)
                switchTile(y, x - 1);
            if (y > 0)
                switchTile(y - 1, x);
            if (x < 2)
                switchTile(y, x + 1);
            if (y < 2)
                switchTile(y + 1, x);
            if (m_numbTillesActive == 9) {
                door.GetComponent<Animator>().SetBool("IsActive", false);
                isActive = true;
            }
        }
    }
}
 