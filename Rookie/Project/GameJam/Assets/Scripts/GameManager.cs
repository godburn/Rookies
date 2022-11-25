using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour { 
    private static GameManager instance;
    public static GameManager Instance {
        get { return instance; }
        private set { instance = value; }
    }

    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public Crow[] crowList;
    public float speed = 2f;
    float score = 0;
    float highscore =0;

    private void Awake() {
        CheckGameManager();
    }

    void CheckGameManager() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad( gameObject );
        } else {
            Destroy( gameObject );
        }
    }

    public void ResetMe() {
        foreach (var c in crowList) {
           c.ResetCrow();
        }
        if (score > highscore) {
            highscore = score;
            int _score = (int)score / 250;
            highScoreText.text = "HIGH : " +_score.ToString() + " feet";

        }
        score = 0;
    }
    public void UpdateScore(float _speed ) {
        speed = _speed;
        score += _speed;
        int _score = (int)score / 250;
        scoreText.text = _score.ToString() + " feet";
    }
}
