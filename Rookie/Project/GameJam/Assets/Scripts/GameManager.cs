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

    public static int playerHealth = 0;
    public bool isPaused = false;
    public float speed = 2f;
    public float distance = 0;
    public TMP_Text scoreText;

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

    void Start() {
        SetupLevel();
    }

    public void SetupLevel() {

    }

    public void UpdateScore(float _speed ) {
        speed = _speed;
        distance += _speed;
        scoreText.text = "Distance : " + distance.ToString();
    }

    public void CursorMode( bool _state ) {
        if (_state) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
