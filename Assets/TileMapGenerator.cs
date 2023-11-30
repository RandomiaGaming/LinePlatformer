using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(fileName = "New Ore", menuName = "WeightedOre")]
public class Ore : ScriptableObject
{
    public Tile ore;
    public int weight;
}

[RequireComponent(typeof(Tilemap))]
public class TileMapGenerator : MonoBehaviour
{
    [HideInInspector]
    public Tilemap tm;
    public int hight;
    private int currenthight;
    private System.Random rnd = new System.Random();
    public RuleTile ground;
    public Tile bedrock;
    public Tile Stone;
    public int distancetilestone;
    public Ore[] ores;
    public Transform player;
    // Use this for initialization
    void Start()
    {
        tm = GetComponent<Tilemap>();
        for (int i = tm.WorldToCell(player.position).x - 15; i <= tm.WorldToCell(player.position).x + 15; i++)
        {
            Generate(i, -1);
        }

    }
    public int SetHight(int pos, int direction)
    {
        if(tm.GetTile(new Vector3Int(pos + direction, 0, 0)) != null)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                if(tm.GetTile(new Vector3Int(pos + direction, 0 + i, 0)) == null){
                    return i - 1;
                }
            }
        }
        else
        {
            return hight;
        }
        return hight;
    }
    public void Generate(int pos, int direction)
    {
        if (tm.GetTile(new Vector3Int(pos, 0, 0)) == null) {
            currenthight = SetHight(pos, direction);
            int[] i = new int[] { 0, 0, 0, 1, -1};
            currenthight += i[rnd.Next(0, i.Length)];
            for (int t = currenthight; t > 0; t--)
            {
                if (t <= currenthight - distancetilestone)
                {
                    tm.SetTile(new Vector3Int(pos, t, 0), Weighted(ores));
                }
                else
                {
                    tm.SetTile(new Vector3Int(pos, t, 0), ground);
                }

            }

            tm.SetTile(new Vector3Int(pos, 0, 0), bedrock);
        }
    }
    public Tile Weighted(Ore[] ores)
    {
        Tile output = new Tile();
        List<Ore> hat = new List<Ore>();
        foreach (Ore o in ores)
        {
            for (int i = 0; i < o.weight; i++)
            {
                hat.Add(o);
            }
        }
        output = hat[rnd.Next(0, hat.ToArray().Length)].ore;
        return output;
    }
}
