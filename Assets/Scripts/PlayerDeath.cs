using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public GameObject Circle;
    public GameObject Square;
    public GameObject Triangle;

    public ParticleSystem ex;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Circle" && other.GetComponent<BoxCollider2D>().isTrigger == false ||
            other.tag == "Square" && other.GetComponent<BoxCollider2D>().isTrigger == false ||
            other.tag == "Triangle" && other.GetComponent<BoxCollider2D>().isTrigger == false )
        {

            ParticleSystem newParticle = (ParticleSystem)Instantiate(ex, Circle.transform.position, transform.rotation);
            var main = newParticle.main;
            main.startColor = Circle.GetComponent<SpriteRenderer>().color;

            ParticleSystem newParticle1 = (ParticleSystem)Instantiate(ex, Triangle.transform.position, transform.rotation);
            var main1 = newParticle1.main;
            main1.startColor = Triangle.GetComponent<SpriteRenderer>().color;

            ParticleSystem newParticle2 = (ParticleSystem)Instantiate(ex, Square.transform.position, transform.rotation);
            var main2 = newParticle2.main;
            main2.startColor = Square.GetComponent<SpriteRenderer>().color;

            FindObjectOfType<AudioManager>().Play("Explode2");

            Invoke("Restart", 3f);

            Destroy(Circle.gameObject);
            Destroy(Square.gameObject);
            Destroy(Triangle.gameObject);


        }

    }

    void Restart()
    {
        Destroy(this.gameObject);
        FindObjectOfType<GameManager>().LoadPreviouslvl();
    }

}
