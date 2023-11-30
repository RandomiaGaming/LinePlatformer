/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldPlayerController : MonoBehaviour {
    private int drawing = 0;
    
    public float slowtime;
    private Rigidbody2D rb2d;
    public GameObject Drawed;
    public float Speed;
    private Vector3 clickpos;
    private LineRenderer drawrenderer;

    public GameObject line;
    public float range;
    private Vector3 mouse;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
    }
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), mouse) > range && Input.GetMouseButton(0))
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(line, mouse, Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.W))
        {

            Undo();
        }

        List<Vector3> list = new List<Vector3>();
        list.Add(clickpos);
        list.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (drawrenderer != null)
        {
            drawrenderer.SetPositions(list.ToArray());
        }
        if (Input.GetMouseButtonDown(0))
        {
            clickpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject draw = Instantiate(Drawed, transform.position, Quaternion.identity);
            draw.GetComponent<undoer>().index = drawing;
            drawing++;
            drawrenderer = draw.GetComponent<LineRenderer>();


            Time.timeScale = slowtime;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }else if (Input.GetMouseButtonUp(0))
        {
            EdgeCollider2D edge = drawrenderer.gameObject.GetComponent<EdgeCollider2D>();
            List<Vector3> test = new List<Vector3>();
            for(int i = 0; i < drawrenderer.positionCount; i++)
            {
                test.Add(drawrenderer.GetPosition(i));
            }
            List<Vector2> test2 = new List<Vector2>();
            foreach(Vector3 t in test)
            {
                test2.Add(new Vector2(t.x, t.y));
            }
            edge.points = test2.ToArray();

            drawrenderer = null;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.0167f;
            
           

        }

        rb2d.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * Speed, 0));
	}
    void Undo()
    {

        
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("drawed"))
        {
           
            if (go.GetComponent<undoer>().index == drawing - 1)
            {
               
                Destroy(go);
                drawing--;
                return;
            }
        }
    }
}
*/