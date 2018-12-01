using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour {

    Vector3 pos1 = new Vector3(0, 6, 0);
    Vector3 pos2 = new Vector3(0, 4, 0);
    Vector3 pos3 = new Vector3(0, 2, 0);
    Vector3 pos4 = new Vector3(0, 0, 0);
    Vector3 pos5 = new Vector3(0, -2, 0);
    Vector3 pos6 = new Vector3(0, -4, 0);
    Vector3 pos7 = new Vector3(0, -6, 0);

    Vector3 target;
	// Use this for initialization
	void Start () 
    {
        target = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () 
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, target, 0.3f);

        ColorChanger();
    }

    public void ColorChanger()
    {
        if (this.transform.position == pos1)
        {
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }

        if (this.transform.position == pos4)
        {
            this.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (this.transform.position == pos6)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }

    }

    public void ShapeMover ()
    {
        target.y -= 1f;
    }


}

