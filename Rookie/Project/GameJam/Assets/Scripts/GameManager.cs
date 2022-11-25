using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour { 


    private static GameManager instance;

    public static GameManager Instance {
        get { return instance; }
        private set { instance = value; }
    }

    public static int playerHealth = 0;
    public bool isPaused = false;
    public float speed = 2f;

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
