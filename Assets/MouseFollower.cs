using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour {
    public Color valid;
    public Color notvalid;
    private SpriteRenderer sr;
    public PlayerMiner playerMiner;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerMiner.tm.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)) + new Vector3(0.5f, 0.5f, 0);
        if (playerMiner.Valid())
        {
            sr.color = valid;
        }
        else
        {
            sr.color = notvalid;
        }
	}
}
