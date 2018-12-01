using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShape : MonoBehaviour {

    public List<GameObject> shapes;

    Vector2 secsBetweenSpawnsMinMax =  new Vector2(0.3f, 1);
    float nextSpawnTime;

    // Use this for initialization
    void Start () 
    {
        GameSetup();


	}
	
	// Update is called once per frame
	void Update () 
    {
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        if (Time.time > nextSpawnTime)
        {
            float secsBetweenSpawns = Mathf.Lerp(secsBetweenSpawnsMinMax.y, secsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secsBetweenSpawns;

            //Debug.Log(secsBetweenSpawns);
            FindObjectOfType<AudioManager>().Play("Spawn");

            foreach (var S in FindObjectsOfType<ShapeManager>())
            {
                S.ShapeMover();
            }
        }

    }



    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.tag == "Shape")
        //{
            GameObject newShape = (GameObject)Instantiate(shapes[Random.Range(0, shapes.Count)], transform.position, transform.rotation);
        //}
    }

    private void GameSetup()
    {

        GameObject newShape = (GameObject)Instantiate(shapes[Random.Range(0, shapes.Count)], transform.position, transform.rotation);
        newShape.GetComponent<SpriteRenderer>().color = Color.green;

    }
}
