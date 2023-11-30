using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerMiner : MonoBehaviour {
    public Tilemap tm;
    public Tile bedrock;
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (Valid())
            {
                tm.SetTile(tm.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)), null);
            }
        }
	}
    public bool Valid()
    {
        Vector3Int i = tm.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Vector3Int p = tm.WorldToCell(transform.position);
        if (i == p + new Vector3Int(0, 1, 0) || i == p + new Vector3Int(-1, 0, 0) || i == p + new Vector3Int(1, 0, 0) || i == p + new Vector3Int(0, -1, 0))
        {
            if(tm.GetTile(i) != bedrock)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        else
        {
            return false;
        }
    }
}
