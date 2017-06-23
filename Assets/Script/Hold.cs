using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour {

    public Spawn spawn;
    public int change, hold;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        GameObject[] mino = GameObject.FindGameObjectsWithTag("mino");

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            //change = spawn.next[0];
            // spawn.next[0] = spawn.hold;
            //spawn.hold = spawn.next[0];change;
            //hold = spawn.now;
            /* foreach (GameObject obj in mino)
                 Destroy(obj);
             FindObjectOfType<Spawn>().SpawnNext();
             enabled = false;
             */
            spawn.Holded(spawn.now);
        }
    }

   
}
