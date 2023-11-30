using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformer : MonoBehaviour {
    public float movespeed;
    private Rigidbody2D rb;
    public float jumpforce;
    public GroundChecker gc;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(movespeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && gc.grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }
}
