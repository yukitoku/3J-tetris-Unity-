﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour {

    float lastfall = 0f;
    public Spawn spawn;
    public int change;

    bool isValidGridPos ()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            if (!Grid.insideBorder(v))
                return false;
            if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid ()
    {
        for (int y = 0; y < Grid.h; ++y)
            for (int x = 0; x < Grid.w; ++x)
                if (Grid.grid[x, y] != null) 
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;

        foreach(Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }
	// Use this for initialization
	void Start () {
        if (!isValidGridPos())
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);
            if (isValidGridPos())
                updateGrid();
            else
                transform.Rotate(0, 0, 90);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Time.time - lastfall >= 1) 
        {
            transform.position += new Vector3(0, -1, 0);

            if (isValidGridPos())
                updateGrid();
            else
            {
                transform.position += new Vector3(0, 1, 0);
                Grid.deleteFullRows();
                FindObjectOfType<Spawn>().SpawnNext();
                enabled = false;
            }
            lastfall = Time.time;
        }
    }
}
