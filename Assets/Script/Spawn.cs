using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] groups = new GameObject[7];
    public GameObject[] nextmino = new GameObject[7];
    public int[] next = new int[5];
    public int now;
    public int nextnum;

	public void SpawnNext () {
        GameObject[] nextobj = GameObject.FindGameObjectsWithTag("nextminos");
        foreach (GameObject obj in nextobj)
            Destroy(obj);

        for (int num = 0; num < 5; num++)
        {
            if (next[num] > 10)
            {
                int i = Random.Range(0, 7);
                next[num] = i;
            }
        }
        now = next[0];
        Instantiate(groups[next[0]], transform.position, Quaternion.identity);
        for (int j = 0; j < 4; j++) 
        {
            next[j] = next[j + 1];
        }
        while(true)
        {
            nextnum = Random.Range(0, 7);
            if (nextnum == next[0] || nextnum == next[1] || nextnum == next[2] || nextnum == next[3]) 
                continue;
            else
                break;
        }
        next[4] = nextnum;
        Instantiate(nextmino[next[0]], new Vector2(15, 15), Quaternion.identity);
        Instantiate(nextmino[next[1]], new Vector2(15, 10), Quaternion.identity);
        Instantiate(nextmino[next[2]], new Vector2(15, 5), Quaternion.identity);
    }
	
	void Start () {
        SpawnNext();
	}
}
