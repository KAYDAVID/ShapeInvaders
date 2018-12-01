using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMover : MonoBehaviour {

    Vector3 target;
    bool isFade = false;
    GameObject fade;

    // Use this for initialization
    private void Awake()
    {
        fade = GameObject.FindWithTag("Fade");
        GameObject.FindWithTag("Fade").SetActive(false);
    }

    void Start () 
    {
        target = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () 
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, target, 0.1f);

        if (FindObjectOfType<Scoring>().GetScore() >= 100 && FindObjectOfType<Scoring>().GetScore() <= 200)
        {
            target.y = 2;
        }

        if (FindObjectOfType<Scoring>().GetScore() >= 200)
        {
            target.y = 0;
        }

        if (FindObjectOfType<Scoring>().GetScore() >= 300 && isFade == false)
        {

            fade.SetActive(true);
            isFade = true;
        }
    }
}
