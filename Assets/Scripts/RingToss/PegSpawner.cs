using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegSpawner : MonoBehaviour
{
    public GameObject peg;
    public GameObject peg3;
    public GameObject peg5;

    int[] xPos = new int[] { -105, -150, -195 };
    int[] zPos = new int[] { -215, -158 };

    int[] xPosFake = new int[] { -90, -135, -185, -205 };
    int[] zPosFake = new int[] { -200, -148, -168, -212 };
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < xPos.Length; i++)
        {
            for (int j = 0; j < zPos.Length; j++)
            {
                int rand = Random.Range(0, 10);
                if (rand == 9)
                {
                    Instantiate(peg5, new Vector3(xPos[i], 8, zPos[j]), Quaternion.identity);
                }
                else if (rand > 7)
                {
                    Instantiate(peg3, new Vector3(xPos[i], 8, zPos[j]), Quaternion.identity);
                }
                else if (rand > 0)
                {
                    Instantiate(peg, new Vector3(xPos[i], 8, zPos[j]), Quaternion.identity);
                }
            }
        }

        for (int i = 0; i < xPosFake.Length; i++)
        {
            for (int j = 0; j < zPosFake.Length; j++)
            {
                int rand = Random.Range(0, 10);
                if (rand == 9)
                {
                    Instantiate(peg5, new Vector3(xPosFake[i], 8, zPosFake[j]), Quaternion.identity);
                }
                else if (rand > 8)
                {
                    Instantiate(peg3, new Vector3(xPosFake[i], 8, zPosFake[j]), Quaternion.identity);
                }
                else if (rand > 4)
                {
                    Instantiate(peg, new Vector3(xPosFake[i], 8, zPosFake[j]), Quaternion.identity);
                }
            }
        }
    }

}
