using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{

    int score = 0;

    GameObject scoreUi;

    GameObject gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        this.scoreUi = GameObject.Find("Score");
        this.gameOverText = GameObject.Find("GameOver");
        this.gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    private void OnTriggerEnter2D(Collider2D other)
    {
        score++;
        Debug.Log("점수 업데이트: " + score);
        this.scoreUi.GetComponent<Text>().text = "Score" + score; 
    }

    public void GameOver() {
        this.gameOverText.SetActive(true);
    }
}

