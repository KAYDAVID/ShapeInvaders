using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    Vector3 target;

    Vector3 center = new Vector3(0, -6, 0);

    static bool isAlive = false;

    int playerPos = 0;

    public ParticleSystem ex;

    // Use this for initialization
    void Start () 
    {
        target = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (playerPos > -1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                target.x -= 2f;
                playerPos--;

                FindObjectOfType<AudioManager>().Play("Move");
            }
        }

        if (playerPos < 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                target.x += 2f;
                playerPos++;

                FindObjectOfType<AudioManager>().Play("Move");
            }
        }

        if (isAlive == false)
        {
            if (this.transform.position == center)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    isAlive = true;
                    GameObject newShape = (GameObject)Instantiate(this.gameObject, transform.position, transform.rotation);
                    newShape.GetComponent<PlayerManager>().enabled = false;
                    if (this.GetComponent<SpriteRenderer>().name == "Triangle") {newShape.tag = "Triangle";}
                    if (this.GetComponent<SpriteRenderer>().name == "Square") { newShape.tag = "Square"; }
                    if (this.GetComponent<SpriteRenderer>().name == "Circle") { newShape.tag = "Circle"; }
                    newShape.AddComponent<Rigidbody2D>();
                    newShape.GetComponent<Rigidbody2D>().gravityScale = 0;
                    newShape.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);

                    //newShape.GetComponent<BoxCollider2D>().isTrigger = false;
                }
            }
        }

        this.transform.position = Vector2.MoveTowards(this.transform.position, target, 0.3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == this.tag)
        {
            isAlive = false;

            ParticleSystem newParticle = (ParticleSystem)Instantiate(ex, transform.position, transform.rotation);
            var main = newParticle.main;
            main.startColor = other.GetComponent<SpriteRenderer>().color;

            FindObjectOfType<AudioManager>().Play("Explode");

            Score(other);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (this.tag == "Triangle" && other.tag == "Square" || 
            this.tag == "Triangle" && other.tag == "Circle")
        {
            isAlive = false;

            ParticleSystem newParticle = (ParticleSystem)Instantiate(ex, transform.position, transform.rotation);
            var main = newParticle.main;
            main.startColor = this.GetComponent<SpriteRenderer>().color;

            FindObjectOfType<AudioManager>().Play("Explode");

            Destroy(gameObject);
        }

        if (this.tag == "Square" && other.tag == "Triangle" ||
            this.tag == "Square" && other.tag == "Circle")
        {
            isAlive = false;

            ParticleSystem newParticle = (ParticleSystem)Instantiate(ex, transform.position, transform.rotation);
            var main = newParticle.main;
            main.startColor = this.GetComponent<SpriteRenderer>().color;

            FindObjectOfType<AudioManager>().Play("Explode");

            Destroy(gameObject);
        }

        if (this.tag == "Circle" && other.tag == "Triangle" ||
            this.tag == "Circle" && other.tag == "Square")
        {

            isAlive = false;

            ParticleSystem newParticle = (ParticleSystem)Instantiate(ex, transform.position, transform.rotation);
            var main = newParticle.main;
            main.startColor = this.GetComponent<SpriteRenderer>().color;

            FindObjectOfType<AudioManager>().Play("Explode");

            Destroy(gameObject);
        }

        if (other.tag == "DestroyLine")
        {
            isAlive = false;

            ParticleSystem newParticle = (ParticleSystem)Instantiate(ex, transform.position, transform.rotation);
            var main = newParticle.main;
            main.startColor = this.GetComponent<SpriteRenderer>().color;

            FindObjectOfType<AudioManager>().Play("Explode");

            Destroy(gameObject);
        }
    }


    void Score (Collider2D other)
    {
        if (other.GetComponent<SpriteRenderer>().color == Color.green)
        {
            FindObjectOfType<Scoring>().AddOne();
        }

        if (other.GetComponent<SpriteRenderer>().color == Color.yellow)
        {
            FindObjectOfType<Scoring>().AddOne();
            FindObjectOfType<Scoring>().AddOne();
            FindObjectOfType<Scoring>().AddOne();
        }

        if (other.GetComponent<SpriteRenderer>().color == Color.red)
        {
            FindObjectOfType<Scoring>().AddOne();
            FindObjectOfType<Scoring>().AddOne();
            FindObjectOfType<Scoring>().AddOne();
            FindObjectOfType<Scoring>().AddOne();
            FindObjectOfType<Scoring>().AddOne();
        }
    }
}
