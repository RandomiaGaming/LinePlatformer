using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTerainLoader : MonoBehaviour {
    public int direction;
    public TileMapGenerator tm;
	void Update () {
        tm.Generate(tm.tm.WorldToCell(transform.position).x, direction);
	}
}
