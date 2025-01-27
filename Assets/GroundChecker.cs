using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GroundChecker : MonoBehaviour
{
    public bool grounded;
    public Transform[] points;
    public Tilemap tm;
    public TileBase[] ground;
    void Update()
    {
        grounded = false;
        foreach (Transform tr in points)
        {
            foreach (TileBase t in ground)
            {
                if (tm.GetTile(tm.WorldToCell(tr.position)) == t)
                {
                    grounded = true;
                }
            }
        }
    }
}
