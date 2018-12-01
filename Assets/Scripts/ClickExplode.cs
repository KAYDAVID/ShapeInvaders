using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExplode : MonoBehaviour {

    public ParticleSystem ex;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnMouseEnter()
    {
        this.transform.localScale = new Vector2(this.transform.localScale.x + 0.1f, this.transform.localScale.y + 0.1f);
    }

    private void OnMouseExit()
    {
        this.transform.localScale = new Vector2(this.transform.localScale.x - 0.1f, this.transform.localScale.y - 0.1f);
    }


    private void OnMouseDown()
    {
        ParticleSystem newParticle = (ParticleSystem)Instantiate(ex, transform.position, transform.rotation);
        var main = newParticle.main;
        main.startColor = this.GetComponent<SpriteRenderer>().color;

        if (this.GetComponent<SpriteRenderer>().color == Color.green)
        {
            Destroy(GameObject.FindWithTag("1pt"));
        }

        if (this.GetComponent<SpriteRenderer>().color == Color.yellow)
        {
            Destroy(GameObject.FindWithTag("3pt"));
        }

        if (this.GetComponent<SpriteRenderer>().color == Color.red)
        {
            Destroy(GameObject.FindWithTag("5pt"));
        }

        FindObjectOfType<AudioManager>().Play("Explode");

        Destroy(gameObject);
    }
}
