using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour {

    public GameObject[] holding = new GameObject[7];
    public Spawn spawn;
    public GameObject change, hold;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        GameObject[] mino = GameObject.FindGameObjectsWithTag("mino");
        GameObject[] mino2 = GameObject.FindGameObjectsWithTag("holded");

        if (Input.GetKeyDown(KeyCode.RightShift))
            {
                if (!hold)
                {
                hold = holding[spawn.now];
                    FindObjectOfType<Spawn>().SpawnNext();
                }
                else
                {
                    change = hold;
                    hold = holding[spawn.now];
                    FindObjectOfType<Spawn>().SpawnNext();
                }
            foreach (GameObject obj in mino)
                Destroy(obj);
            foreach (GameObject obj2 in mino2)
                Destroy(obj2);
            Instantiate(holding[spawn.now], transform.position, Quaternion.identity);
           }
       }
    
}
