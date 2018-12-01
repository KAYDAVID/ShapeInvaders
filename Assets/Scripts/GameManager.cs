using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    // Use this for initialization

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start () 
    {
        FindObjectOfType<AudioManager>().Play("Spacey");
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
            Application.Quit();
        }*/
    }

    public void LoadNextlvl ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPreviouslvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
