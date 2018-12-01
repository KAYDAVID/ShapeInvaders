using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour {

    public static Scoring instance;

    public GameObject Score;
    public GameObject HighScore;

    TextMeshProUGUI score;
    TextMeshProUGUI hscore;

    private int INTscore = 0;
    private int INThscore = 0;

    private void Start()
    {
        score = Score.GetComponent<TextMeshProUGUI>();
        hscore = HighScore.GetComponent<TextMeshProUGUI>();

        loadHighScore();

        Debug.Log(PlayerPrefs.GetInt("HighScore").ToString());

        //UpdateScore();
    }

    // Update is called once per frame
    void Update () 
    {
        UpdateScore();
    }

    void loadHighScore ()
    {
        hscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void UpdateScore ()
    {
        score.text = INTscore.ToString();

        if (INTscore >= PlayerPrefs.GetInt("HighScore"))
        {
            INThscore = INTscore;
            PlayerPrefs.SetInt("HighScore", INThscore);
            hscore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    public void AddOne ()
    {
        INTscore++;
        UpdateScore();
    }

    public int GetScore ()
    {
        return INTscore;
    }

}
