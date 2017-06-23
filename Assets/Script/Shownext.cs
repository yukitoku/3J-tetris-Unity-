using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shownext : MonoBehaviour {

    public Spawn spawn;
	// Use this for initialization
	void Start () {
        for (int i = 1; i < 5; i++)
        {
            //Instantiate(Spawn.groups[Spawn.next[i]], new Vector2(0.5f, i), Quaternion.identity);
            //enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
     
    }
}
