using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_PlayerLife : MonoBehaviour
{
    public Image image;
    public Sprite HeartFull;
    public Sprite HeartTreeQuarter;
    public Sprite HeartTwoQuarter;
    public Sprite HeartOneQuarter;
    public Sprite HeartEmpty;
    public int NbrOfHeart = 8;
    Image[] images;

    public int curentLife = 8;

    void Awake()
    {
        Vector3 pos = transform.position;
        images = new Image[NbrOfHeart];

        for (int i = 0; i != NbrOfHeart; i++) {
            images[i] = Instantiate(image, pos, Quaternion.identity);
            images[i].transform.parent = transform.parent;
            pos.x += 60;
            if ((i + 1) % 8 == 0 && i != 1) {
                pos.x = transform.position.x;
                pos.y += 50;
            }
        }
        setLife(curentLife);
    }

    void setLife(int life)
    {
        Sprite texture;
        int life_save = 4;

        for (int i = 0; i != NbrOfHeart; i++) {
            if ((life - i * 4) > 0)
            {
                print("Life save : " + life_save + " life : " + life);
                print((life_save <= life) ? 0 : life_save - life);
                switch ((life_save <= life) ? 0 : life_save - life)
                {
                    case 1:
                        texture = HeartTreeQuarter;
                        break;
                    case 2:
                        texture = HeartTwoQuarter;
                        break;
                    case 3:
                        texture = HeartOneQuarter;
                        break;
                    default:
                        texture = HeartFull;
                        break;
                }
                life_save += 4;
            }
            else {
                texture = HeartEmpty;
            }
            images[i].sprite = texture;
        }
    }
}
